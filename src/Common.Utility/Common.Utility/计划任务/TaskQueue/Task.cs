using System;

namespace TaskQueue
{
    public class Task : ITask
    {
        public string Id { get; set; }

        public DateTime StartTime { get; set; }

        public Action TaskAction { get; set; }

        /// <summary>
        /// TimeSpan.Zero mean null
        /// </summary>
        public TimeSpan Recurrence { get; set; }

        public Task(Action taskAction, string taskId = null)
        {
            TaskAction = taskAction;
            StartTime = DateTime.Now;
            Recurrence = TimeSpan.Zero;
            Id = taskId;
        }
        public Task(Action taskAction, DateTime startTime, string taskId = null)
        {
            TaskAction = taskAction;
            StartTime = startTime;
            Recurrence = TimeSpan.Zero;
            Id = taskId;
        }
        public Task(Action taskAction, DateTime startTime, TimeSpan recurrence, string taskId = null)
        {
            TaskAction = taskAction;
            StartTime = startTime;
            Recurrence = recurrence;
            Id = taskId;
        }

        public void Run()
        {
            TaskAction();
        }

        public DateTime GetNextRunTime(DateTime lastExecutionTime)
        {
            return Recurrence != TimeSpan.Zero ? lastExecutionTime.Add(Recurrence) : DateTime.MinValue;
        }
    }

    public class Task<T> : ITask<T>
    {
        public T Param { get; set; }

        public Action<T> TaskAction { get; set; }

        public Task(Action<T> taskAction, T param = default(T))
        {
            TaskAction = taskAction;
            Param = param;
        }

        public void Run(T o)
        {
            TaskAction(o);
        }
    }
}
