using System;
using System.Text;
using Common.Utility.Test;
using NNanomsg.Protocols;

namespace NNanomsg
{
    public class ReqRep
    {
        static void Node0(string url)
        {
            using (var s = new ReplySocket())
            {
                s.Bind(url);
                Console.WriteLine("NODE0: RECEIVED: \"" + Encoding.UTF8.GetString(s.Receive()) + "\"");
                const string sendText = "Goodbye.";
                Console.WriteLine("NODE0: SENDING: \"" + sendText + "\"");
                s.Send(Encoding.UTF8.GetBytes(sendText));
            }
        }

        static void Node1(string[] args)
        {
            var socketAddress = args[2];
            if (args.Length == 7 && args[3].Equals("benchmark") && int.TryParse(args[4], out var threadCount) && int.TryParse(args[5], out var count) && int.TryParse(args[6], out var bufSize))
            {
                Benchmark.Run(async (threadId, bufferCapacity, loopCount, dataList, receivedAction, completedAction) =>
                {
                    var address = socketAddress + threadId;
                    using (var s = new RequestSocket())
                    {
                        try
                        {
                            s.Connect(address);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Connect Error! " + Environment.NewLine + ex);
                            return;
                        }

                        // 发送和接收数据
                        var rnd = new Random();
                        for (var j = 0; j < loopCount; j++)
                        {
                            try
                            {
                                var payload = dataList[rnd.Next(0, dataList.Length)];
                                s.Send(payload);
                                s.Receive();
                                receivedAction();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("IO Error! " + Environment.NewLine + ex);
                                return;
                            }
                        }
                    }

                    completedAction();
                }, threadCount, count, bufSize);
            }
            else
            {
                using (var s = new RequestSocket())
                {
                    s.Connect(socketAddress);
                    const string sendText = "Hello, World!";
                    Console.WriteLine("NODE1: SENDING \"" + sendText + "\"");
                    s.Send(Encoding.UTF8.GetBytes(sendText));
                    Console.WriteLine("NODE1: RECEIVED: \"" + Encoding.UTF8.GetString(s.Receive()) + "\"");
                }
            }
        }

        public static void Execute(string[] args)
        {
            switch (args[1])
            {
                case "node0":
                    Node0(args[2]);
                    break;
                case "node1":
                    Node1(args);
                    break;
                default:
                    Console.WriteLine("Usage: ...");
                    break;
            }
        }
    }
}
