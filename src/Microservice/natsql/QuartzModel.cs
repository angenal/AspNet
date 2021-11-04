using LiteDB;
using System;

namespace natsql
{
    /// <summary>
    /// Quartz StartAt Job
    /// </summary>
    public class QuartzStartAtJob
    {
        /// <summary>
        /// Id
        /// </summary>
        public ObjectId Id { get; set; }
        /// <summary>
        /// 任务名+组名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 时间戳(秒)
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// 状态 0:未执行 1:已执行 2:已删除
        /// </summary>
        public int Status { get; set; }

        public static long Now() => DateTimeOffset.Now.ToUnixTimeSeconds();

        public QuartzStartAtJob(string name, string data, long time)
        {
            Id = ObjectId.NewObjectId();
            Name = name;
            Data = data;
            Time = time;
            if (Time < 1) Status = 2;
        }

        public QuartzStartAtJob(string name, string data, DateTime dateTime)
        {
            Id = ObjectId.NewObjectId();
            Name = name;
            Data = data;
            Time = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
            if (Time < 1) Status = 2;
        }
    }
}
