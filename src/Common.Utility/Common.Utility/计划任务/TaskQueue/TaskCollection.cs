using System.Collections;
using System.Collections.Generic;

namespace TaskQueue
{
    internal class TaskCollection : IEnumerable<ITask>
    {
        private readonly List<ITask> tasks;

        public TaskCollection()
        {
            tasks = new List<ITask>();
        }

        public void Add(ITask item)
        {
            var index = IndexOf(item);
            if (index > -1)
                tasks.Insert(index + 1, item);
            else
                tasks.Insert(~index, item);
        }

        public bool Remove(ITask item)
        {
            var index = IndexOf(item);
            if (index < 0) return false;
            tasks.RemoveAt(index);
            return true;
        }

        public ITask First()
        {
            return tasks.Count > 0 ? tasks[0] : null;
        }

        /// <summary>
        /// Returns the index of <paramref name="item"/> using Binary Search
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(ITask item)
        {
            return tasks.BinarySearch(item, new TaskComparer());
        }

        public void RemoveAt(int index)
        {
            tasks.RemoveAt(index);
        }

        public void Clear()
        {
            tasks.Clear();
        }

        public bool Contains(ITask item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(ITask[] array, int arrayIndex)
        {
            tasks.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ITask> GetEnumerator()
        {
            return ((IEnumerable<ITask>)tasks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ITask>)tasks).GetEnumerator();
        }

        public int Count => tasks.Count;

        public ITask this[int index] => tasks[index];
    }
}
