using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService.SignalR.Server.ServiceRepository
{
    /// <summary>
    /// 模块 发送消息
    /// </summary>
    public class SendMessageRepository : BaseRepository
    {
        public SendMessageRepository() : base()
        {
            db.IgnoreColumns.Add("SendTimes", "SendMessages");
        }

        /// <summary>
        /// 数据库访问
        /// </summary>
        public ISugarQueryable<Entity.SendMessages> Qs() { return db.Queryable<Entity.SendMessages>(); }

        /// <summary>
        /// 查询未发送的消息列表
        /// </summary>
        /// <param name="lastTime"></param>
        /// <returns></returns>
        public async Task<List<Entity.SendMessages>> GetNoSended(TimeSpan lastTime)
        {
            var qs = this.Qs().Where(q => q.SendState == false);

            if (lastTime.Equals(TimeSpan.Zero))
            {
                DateTime sendTime = DateTime.Now;
                qs = qs.Where(q => q.SendTime >= sendTime);
            }
            else if (lastTime.Equals(TimeSpan.MaxValue) || lastTime.Equals(TimeSpan.MinValue))
            {
                // select all
            }
            else
            {
                DateTime sendTime = DateTime.Now.Add(lastTime);
                qs = qs.Where(q => q.SendTime >= sendTime);
            }

            return await qs.Select(q => q).ToListAsync();
        }

        /// <summary>
        /// 添加消息发送
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="msg"></param>
        /// <param name="sendTime"></param>
        /// <returns></returns>
        public async Task<Guid> Add(string from, string to, string msg, DateTime sendTime)
        {
            var model = new Entity.SendMessages()
            {
                Id = Guid.NewGuid(),
                UserIdFrom = from,
                UserIdTo = to,
                Message = msg,
                SendTime = sendTime,
                SendState = false
            };

            int i = await db.Insertable(model).ExecuteCommandAsync();

            if (0 == i)
            {
                throw new Exception("添加消息失败");
            }

            return model.Id;
        }

        /// <summary>
        /// 更新发送消息状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sendState"></param>
        /// <returns></returns>
        public async Task<bool> UpdateState(Guid id, bool sendState)
        {
            int i = await db.Updateable<Entity.SendMessages>()
                .UpdateColumns(q => new Entity.SendMessages { SendState = sendState })
                .Where(q => q.Id == id)
                .ExecuteCommandAsync();

            return (0 < i);
        }

    }
}
