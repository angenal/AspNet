using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utility.Test
{
    public static class Benchmark
    {
        public static void Run(Action<int, int, long, byte[][], Action, Action> threadTask, int threadCount = 4, long loopCount = 10000, int bufSize = 256, int dataListCount = 256)
        {
            // Generate random data to be written
            var random = new Random();
            var dataList = new byte[dataListCount][];
            for (var j = 0; j < dataListCount; j++)
            {
                var data = new byte[bufSize];
                random.NextBytes(data);
                dataList[j] = data;
            }

            var bufferCapacity = bufSize;
            Console.WriteLine($"Thread count: {threadCount}");
            //Console.WriteLine($"Buffer size: {bufferCapacity}");
            Console.WriteLine($"Message size: {bufSize}");
            //Console.WriteLine("Running...");
            long count = 0, completed = 0;
            var watch = Stopwatch.StartNew();

            for (var i = 0; i < threadCount; i++)
            {
                var threadId = i;
                new Task(() => { threadTask.Invoke(threadId, bufferCapacity, loopCount, dataList, () => Interlocked.Increment(ref count), () => Interlocked.Increment(ref completed)); }).Start();
            }

            while (Interlocked.Read(ref completed) < threadCount) Thread.Sleep(0);
            watch.Stop();

            Console.WriteLine($"{count} in {watch.Elapsed}, {(int)(count / watch.Elapsed.TotalSeconds)} requests / sec");
        }
    }
}
