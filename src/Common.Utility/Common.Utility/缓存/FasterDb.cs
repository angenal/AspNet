using FASTER.core;
using System;
using System.Diagnostics;
using System.IO;

namespace Common.Utility
{
    using Common.Utility.FasterCache;

    /// <summary>
    /// Fast key-value store from Microsoft Research
    /// NuGet: FASTER @ 2019.1.12.1
    /// https://github.com/Microsoft/FASTER
    /// </summary>
    public sealed class FasterDb
    {
        /// <summary>
        /// 测试读写次数(qps) 读:10万/s 写:30万/s
        /// </summary>
        public static void CacheTest()
        {
            var context = default(CacheContext);

            var log = Devices.CreateLogDevice(Path.GetTempPath() + "hlog.log", deleteOnClose: true);
            var objlog = Devices.CreateLogDevice(Path.GetTempPath() + "hlog.obj.log", deleteOnClose: true);
            var h = new FasterKV<CacheKey, CacheValue, CacheInput, CacheOutput, CacheContext, CacheFunctions>(
                1L << 20, new CacheFunctions(), new LogSettings { LogDevice = log, ObjectLogDevice = objlog }, null,
                new SerializerSettings<CacheKey, CacheValue> { keySerializer = () => new CacheKeySerializer(), valueSerializer = () => new CacheValueSerializer() });

            h.StartSession();

            const int recordsMax = 10000000, refreshMax = 256;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < recordsMax; i++)
            {
                if (i % refreshMax == 0)
                {
                    h.Refresh();
                    if (i % (1 << 19) == 0) Console.WriteLine($"{i}: {MemoryUsedMb()}M");
                }
                var key = new CacheKey(i.ToString());
                var value = new CacheValue(i.ToString());
                h.Upsert(ref key, ref value, context, 0);
            }
            sw.Stop();
            Console.WriteLine("Total time to upsert {0} elements: {1:0.000} secs ({2:0.00} inserts/sec)", recordsMax, sw.ElapsedMilliseconds / 1000.0, recordsMax / (sw.ElapsedMilliseconds / 1000.0));


            Console.WriteLine("Issuing uniform random read workload");

            var rnd = new Random();

            int statusPending = 0;
            var output = new CacheOutput();
            var input = default(CacheInput);
            sw.Restart();
            for (int i = 0; i < recordsMax; i++)
            {
                long k = rnd.Next(recordsMax);

                var key = new CacheKey(k.ToString());
                var status = h.Read(ref key, ref input, ref output, context, 0);

                switch (status)
                {
                    case Status.PENDING:
                        h.CompletePending(true);
                        statusPending++; break;
                    case Status.ERROR:
                        throw new Exception("Error!");
                }
                if (output.value.value != key.key)
                    throw new Exception("Read error!");
            }
            sw.Stop();

            h.StopSession();

            Console.WriteLine("Total time to read {0} elements: {1:0.000} secs ({2:0.00} reads/sec)", recordsMax, sw.ElapsedMilliseconds / 1000.0, recordsMax / (sw.ElapsedMilliseconds / 1000.0));
            Console.WriteLine($"Reads completed with PENDING: {statusPending}");
            Console.WriteLine();
            Console.WriteLine($"Total memory: {MemoryUsedMb()}M <<< Total records: {(recordsMax / 10000):#}w");
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static readonly Func<long> MemoryUsedMb = () => Process.GetCurrentProcess().WorkingSet64 / 1048576;

    }
}

namespace Common.Utility.FasterCache
{
    public class CacheKey : IFasterEqualityComparer<CacheKey>
    {
        public string key;

        public CacheKey() { }

        public CacheKey(string first)
        {
            key = first;
        }

        public long GetHashCode64(ref CacheKey key)
        {
            return key.key.GetHashCode();
            //return FASTER.core.Utility.GetHashCode(key.key);
        }
        public bool Equals(ref CacheKey k1, ref CacheKey k2)
        {
            return k1.key == k2.key;
        }
    }

    public class CacheKeySerializer : BinaryObjectSerializer<CacheKey>
    {
        public override void Deserialize(ref CacheKey obj)
        {
            //obj.key = reader.ReadInt64();
            obj.key = reader.ReadString();
        }

        public override void Serialize(ref CacheKey obj)
        {
            writer.Write(obj.key);
        }
    }

    public class CacheValue
    {
        public string value;

        public CacheValue() { }

        public CacheValue(string first)
        {
            value = first;
        }
    }

    public class CacheValueSerializer : BinaryObjectSerializer<CacheValue>
    {
        public override void Deserialize(ref CacheValue obj)
        {
            //obj.value = reader.ReadInt64();
            obj.value = reader.ReadString();
        }

        public override void Serialize(ref CacheValue obj)
        {
            writer.Write(obj.value);
        }
    }

    public struct CacheInput
    {
    }

    public struct CacheOutput
    {
        public CacheValue value;
    }

    public struct CacheContext
    {
    }

    public class CacheFunctions : IFunctions<CacheKey, CacheValue, CacheInput, CacheOutput, CacheContext>
    {
        public void ConcurrentReader(ref CacheKey key, ref CacheInput input, ref CacheValue value, ref CacheOutput dst)
        {
            dst.value = value;
        }

        public void ConcurrentWriter(ref CacheKey key, ref CacheValue src, ref CacheValue dst)
        {
            dst = src;
        }

        public void SingleReader(ref CacheKey key, ref CacheInput input, ref CacheValue value, ref CacheOutput dst)
        {
            dst.value = value;
        }

        public void SingleWriter(ref CacheKey key, ref CacheValue src, ref CacheValue dst)
        {
            dst = src;
        }

        public void CopyUpdater(ref CacheKey key, ref CacheInput input, ref CacheValue oldValue, ref CacheValue newValue)
        {
            throw new NotImplementedException();
        }

        public void InitialUpdater(ref CacheKey key, ref CacheInput input, ref CacheValue value)
        {
            throw new NotImplementedException();
        }

        public void InPlaceUpdater(ref CacheKey key, ref CacheInput input, ref CacheValue value)
        {
            throw new NotImplementedException();
        }

        public void CheckpointCompletionCallback(Guid sessionId, long serialNum)
        {
            throw new NotImplementedException();
        }

        public void ReadCompletionCallback(ref CacheKey key, ref CacheInput input, ref CacheOutput output, CacheContext ctx, Status status)
        {
            throw new NotImplementedException();
        }

        public void RMWCompletionCallback(ref CacheKey key, ref CacheInput input, CacheContext ctx, Status status)
        {
            throw new NotImplementedException();
        }

        public void UpsertCompletionCallback(ref CacheKey key, ref CacheValue value, CacheContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}
