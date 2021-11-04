using System;
using System.Collections.Generic;

namespace TaskQueue
{
    public interface ITask
    {
        /// <summary>
        /// Task Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Time when task is going to start running.
        /// StartTime is updated after every execution based on NextRunTime (recurrence)<see cref="GetNextRunTime(DateTime)"/>
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Method executed when task is due
        /// </summary>
        void Run();

        /// <summary>
        /// Provide the NextRunTime based on <paramref name="lastExecutionTime"/>.
        /// Returns DateTime.MinValue if task doesn't recurr.
        /// </summary>
        /// <param name="lastExecutionTime"></param>
        /// <returns>Returns DateTime.MinValue if task doesn't recurr</returns>
        DateTime GetNextRunTime(DateTime lastExecutionTime);
    }

    public interface ITask<T>
    {
        T Param { get; set; }

        /// <summary>
        /// Method executed when task is due
        /// </summary>
        void Run(T o);
    }

    public class TaskComparer : IComparer<ITask>
    {
        public int Compare(ITask x, ITask y)
        {
            return DateTime.Compare(x.StartTime, y.StartTime);
        }
    }
}
