using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace TaskQueue
{
    /// <summary>
    /// TaskQueue: Fast, Small, Doesn't poll, Recurring Tasks
    /// </summary>
    public class TaskQueue : IDisposable
    {
        private TaskCollection queue;

        private AutoResetEvent resetEvent;

        private Thread thread;

        private bool started = false;
        public bool Started => started;

        public TaskQueue()
        {
            queue = new TaskCollection();
            resetEvent = new AutoResetEvent(false);
        }

        /// <summary>
        /// Start running tasks
        /// </summary>
        public void Start()
        {
            if (started) return;
            lock (queue)
            {
                if (started) return;
                started = true;
                thread = new Thread(Run) { IsBackground = true };
                thread.Start();
            }
        }

        public void Stop()
        {
            if (!started) return;
            started = false;
            WriteLog("Task Queue thread stopping");
            resetEvent.Set();
            WriteLog("AutoResetEvent set called");
            thread.Join();
            WriteLog("Task Queue thread stopped");
        }

        public void Dispose()
        {
            Stop();
            resetEvent.Dispose();
        }

        /// <summary>
        /// Add a task
        /// </summary>
        /// <param name="task">Once ITask object is added, it should never be updated from outside TaskScheduler</param>
        public void AddTask(ITask task)
        {
            ITask earliestTask;

            lock (queue)
            {
                earliestTask = GetEarliestScheduledTask();
                queue.Add(task);
            }
            WriteLog("Added task # " + task.Id);

            if (earliestTask == null || task.StartTime < earliestTask.StartTime)
            {
                resetEvent.Set();
                WriteLog("AutoResetEvent is Set");
            }
        }

        public void AddTask(Action taskAction, DateTime startTime)
        {
            AddTask(new Task(taskAction, startTime, TimeSpan.Zero));
        }

        public void AddTask(Action taskAction, DateTime startTime, TimeSpan recurrence)
        {
            AddTask(new Task(taskAction, startTime, recurrence));
        }

        private void ReScheduleRecurringTask(ITask task)
        {
            var nextRunTime = task.GetNextRunTime(task.StartTime);
            if (nextRunTime == DateTime.MinValue) return;
            task.StartTime = nextRunTime;
            lock (queue) queue.Add(task);
            WriteLog("Recurring task # " + task.Id + " scheduled for " + task.StartTime);
        }

        private ITask GetEarliestScheduledTask()
        {
            lock (queue) return queue.First();
        }

        public int TaskCount => queue.Count;

        public bool RemoveTask(ITask task)
        {
            WriteLog("Removing task # " + task.Id);
            lock (queue) return queue.Remove(task);
        }

        public bool RemoveTask(string taskId)
        {
            lock (queue) return queue.Remove(queue.First(n => n.Id == taskId));
        }

        public bool UpdateTask(ITask task, DateTime startTime)
        {
            WriteLog("Updating task # " + task.Id + " (Remove & Add)");
            lock (queue)
            {
                if (!RemoveTask(task)) return false;
                task.StartTime = startTime;
                AddTask(task);
                return true;
            }
        }

        private void Run()
        {
            WriteLog("Task Queue thread starting");
            var tolerance = TimeSpan.FromSeconds(1);
            while (started)
            {
                try
                {
                    ITask task = GetEarliestScheduledTask();
                    if (task != null)
                    {
                        if (task.StartTime - DateTime.Now < tolerance)
                        {
                            WriteLog("Starting task " + task.Id);
                            try
                            {
                                task.Run();
                            }
                            catch (Exception e)
                            {
                                WriteLog("Exception while running Task # " + task.Id);
                                WriteLog(e.ToString());
                            }
                            WriteLog("Completed task " + task.Id);
                            lock (queue) queue.Remove(task);
                            ReScheduleRecurringTask(task);
                        }
                        else
                        {
                            TimeSpan waitTime = task.StartTime - DateTime.Now, min15 = TimeSpan.FromMinutes(15);
                            if (waitTime > min15) waitTime = min15;

                            WriteLog("Queue thread waiting for " + waitTime);
                            resetEvent.WaitOne(waitTime);
                            WriteLog("Queue thread awakening from sleep " + waitTime);
                        }
                    }
                    else
                    {
                        WriteLog("Queue thread waiting indefinitely");
                        resetEvent.WaitOne();
                        WriteLog("Queue thread awakening from indefinite sleep");
                    }
                }
                catch (Exception e)
                {
                    WriteLog("Exception: " + e);
                }
            }

        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void SetupConsoleListener()
        {
            System.Diagnostics.Debug.Listeners.Clear();
            System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void WriteLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.Now + "  " + message);
        }
    }

    /// <summary>
    /// TaskQueue: Fast, Small, Doesn't poll, Recurring Tasks
    /// </summary>
    public class TaskQueue<T> : IDisposable
    {
        private readonly ConcurrentQueue<ITask<T>> queue;

        private readonly SemaphoreSlim semaphore;

        private readonly TimeSpan interval;

        private readonly TimeSpan timeout;

        private Thread thread;

        private bool started;

        public TaskQueue() : this(TimeSpan.Zero, TimeSpan.FromSeconds(30))
        { }

        public TaskQueue(TimeSpan interval, TimeSpan timeout)
        {
            this.interval = interval;
            this.timeout = timeout;
            queue = new ConcurrentQueue<ITask<T>>();
            semaphore = new SemaphoreSlim(0);
        }

        /// <summary>
        /// Start running tasks
        /// </summary>
        public void Start()
        {
            if (started) return;
            try
            {
                thread = new Thread(Run) { IsBackground = true };
                thread.Start();
                started = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Stop()
        {
            if (!started) return;
            try
            {
                started = false;
                semaphore.Release();
                thread.Join();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Dispose()
        {
            Stop();
        }

        /// <summary>
        /// Add a task
        /// </summary>
        /// <param name="task">Once ITask object is added, it should never be updated</param>
        public void AddTask(ITask<T> task)
        {
            if (!started) return;
            queue.Enqueue(task);
            semaphore.Release();
        }

        public void AddTask(Action<T> taskAction, T param = default(T))
        {
            if (!started) return;
            var task = new Task<T>(taskAction, param);
            queue.Enqueue(task);
            semaphore.Release();
        }

        private void Run()
        {
            var isInterval = interval != TimeSpan.Zero && interval.TotalMilliseconds > 0;
            while (started)
            {
                if (isInterval) Thread.Sleep(interval);
                try
                {
                    semaphore.Wait(timeout);
                    while (queue.TryDequeue(out var task))
                    {
                        var task0 = task;
                        var task1 = System.Threading.Tasks.Task.Delay(timeout);
                        var task2 = System.Threading.Tasks.Task.Factory.StartNew(() => task0.Run(task0.Param));
                        System.Threading.Tasks.Task.WhenAny(task1, task2).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
