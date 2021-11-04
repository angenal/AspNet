using ServiceStack;
using System;
using System.Threading.Tasks;
using WindowsService.SignalR.Server.ServiceModel;
using WindowsService.SignalR.Server.ServiceRepository;

namespace WindowsService.SignalR.Server.ServiceInterface
{
    public class SendMessageServices : Service
    {
        public object Any(MessageQuery request)
        {
            var qs = new SendMessageRepository().Qs();

            if (!string.IsNullOrWhiteSpace(request.q))
            {
                qs = qs.Where(q => q.Message.Contains(request.q));
            }

            var qt = qs.Select(q => new MessageViewModel
            {
                id = q.Id,
                from = q.UserIdFrom,
                to = q.UserIdTo,
                msg = q.Message,
                time = q.SendTime,
                state = q.SendState
            });

            System.Diagnostics.Debug.WriteLine($"{nameof(SendMessageServices)} : {qt.ToSql().Key}");

            var list = qt.ToList();

            return new MessageQueryResponse { list = list };
        }
    }
}