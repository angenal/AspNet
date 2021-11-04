using System;
using System.Text;
using System.Threading;
using Common.Utility.Test;
using NNanomsg.Protocols;

namespace NNanomsg
{
    public class Bus
    {
        public static void Execute(string[] args)
        {
            /* Usage: 
			* start example.exe bus ipc:///busexample.0 ipc:///busexample.1 ipc:///busexample.2
			* start example.exe bus ipc:///busexample.1 ipc:///busexample.2
			* start example.exe bus ipc:///busexample.2
			*/
            if (args.Length > 1 && args[1].StartsWith("ipc:///bus"))
            {
                Console.WriteLine(string.Join(" ", args));
                using (var sock = new BusSocket())
                {
                    sock.Bind(args[1]);
                    for (var i = 2; i < args.Length; i++) sock.Connect(args[i]);
                    while (true)
                    {
                        var b = sock.ReceiveImmediate();
                        if (b != null) Console.WriteLine(Encoding.ASCII.GetString(b));
                        if (!Console.KeyAvailable) continue;
                        var output = args[1] + ":" + Console.ReadLine();
                        sock.Send(Encoding.ASCII.GetBytes(output));
                    }
                }
            }
            else if (args.Length > 2 && int.TryParse(args[1], out var threadCount) && int.TryParse(args[2], out var count))
            {
                Benchmark.Run(async (threadId, bufferCapacity, loopCount, dataList, receivedAction, completedAction) =>
                {
                    Thread.Sleep(threadId * 800 + 10);
                    var address = "ipc:///bus." + threadId;
                    if (threadId == 0) { address = ""; for (var i = 0; i < threadCount; i++) address += "ipc:///bus." + threadId + " "; }
                    address = address.TrimEnd();
                    var addresses = address.Split(' ');
                    using (var sock = new BusSocket())
                    {
                        try
                        {
                            sock.Bind(address);
                            foreach (var add in addresses) sock.Connect(add);
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
                            var payload = dataList[rnd.Next(0, dataList.Length)];

                            try
                            {
                                var b = sock.ReceiveImmediate();
                                if (b != null) receivedAction();
                                //if (b != null) Console.WriteLine(Encoding.ASCII.GetString(b));
                                //if (!Console.KeyAvailable) continue;
                                //var output = args[1] + ":" + Console.ReadLine();
                                sock.Send(payload);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("IO Error! " + Environment.NewLine + ex);
                                return;
                            }
                        }
                    }

                    completedAction();
                }, threadCount, count, args.Length > 3 ? int.Parse(args[3]) : 512);

            }
        }
    }
}
