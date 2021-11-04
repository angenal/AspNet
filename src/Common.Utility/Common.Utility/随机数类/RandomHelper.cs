using System;
using System.Collections.Generic;

namespace Common.Utility
{
    /// <summary>
    /// 使用Random类生成伪随机数
    /// </summary>
    public class RandomHelper
    {
        #region 生成一个指定范围的随机整数
        /// <summary>
        /// 生成一个指定范围的随机整数，该随机数范围包括最小值，但不包括最大值
        /// </summary>
        /// <param name="minNum">最小值</param>
        /// <param name="maxNum">最大值</param>
        public int GetRandomInt(int minNum, int maxNum)
        {
            return _random.Next(minNum, maxNum);
        }
        #endregion

        #region 生成一个0.0到1.0的随机小数
        /// <summary>
        /// 生成一个0.0到1.0的随机小数
        /// </summary>
        public double GetRandomDouble()
        {
            return _random.NextDouble();
        }
        #endregion

        #region 对一个数组进行随机排序
        /// <summary>
        /// 对一个数组进行随机排序
        /// </summary>
        /// <typeparam name="T">数组的类型</typeparam>
        /// <param name="list">需要随机排序的数组</param>
        public void GetRandomArray<T>(T[] list)
        {
            for (int n = 0; n < list.Length; n++)
            {
                int i = _random.Next(0, list.Length);
                int j = _random.Next(0, list.Length);
                swap(ref list, i, j);
            }
        }

        #endregion

        #region 内部方法
        /// <summary>
        /// 随机数对象
        /// </summary>
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// 交换两个随机数位置的值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void swap<T>(ref T[] nums, int i, int j)
        {
            T tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
        internal static int GetRandomSeed()
        {
            return Guid.NewGuid().GetHashCode();
        }
        #endregion
    }
}
