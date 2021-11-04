using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace WindowsService.SignalR.Server.ServiceModel
{

    #region 查询消息

    /// <summary>
    /// 请求 输入
    /// </summary>
    [Route("/mq/{q}", Verbs = "GET")]
    public class MessageQuery : IReturn<MessageQueryResponse>
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string q { get; set; }
    }

    /// <summary>
    /// 响应 输出
    /// </summary>
    public class MessageQueryResponse
    {
        /// <summary>
        /// 消息列表
        /// </summary>
        public List<MessageViewModel> list { get; set; }
    }

    /// <summary>
    /// 消息 ViewModel
    /// </summary>
    public class MessageViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public string to { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime time { get; set; }

        /// <summary>
        /// 发送状态,是否成功?
        /// </summary>
        public bool state { get; set; }
    }

    #endregion


}