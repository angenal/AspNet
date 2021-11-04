using System.Collections;
using System.Collections.Generic;

namespace WindowsWPF.Helpers
{
    public static class EnumerableHelper
    {
        public static int Count(this IEnumerable eunmerable)
        {
            if (eunmerable == null)
                return 0;

            int nSize = 0;
            foreach (var item in eunmerable)
                nSize++;

            return nSize;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> eunmerable)
        {
            if (eunmerable == null)
                return default;

            var vEnumerator = eunmerable.GetEnumerator();
            if (vEnumerator.MoveNext())
                return vEnumerator.Current;
            else
                return default;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> eunmerable)
        {
            if (eunmerable == null)
                return default;

            var vEnumerator = eunmerable.GetEnumerator();
            for (; ; )
            {
                if (!vEnumerator.MoveNext())
                    break;
            }

            return vEnumerator.Current;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            if (dictionary == null)
                return defaultValue;

            if (dictionary.TryGetValue(key, out TValue value))
                return value;
            else
                return defaultValue;
        }
    }
}
