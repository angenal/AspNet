using System;
using SqlSugar;

namespace WindowsService.SignalR.Server.ServiceRepository.Entity
{
    /// <summary>
    /// 消息 Model
    /// </summary>
    [SugarTable("SendMessages")]
    public class SendMessages
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
        [SugarColumn(Length = 32)]
        public string UserIdFrom { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        [SugarColumn(Length = 32)]
        public string UserIdTo { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [SugarColumn(Length = 500)]
        public string Message { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 发送状态,是否成功?
        /// </summary>
        public bool SendState { get; set; }

        /// <summary>
        /// 发送累计次数
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int SendTimes { get; set; }
    }
}
