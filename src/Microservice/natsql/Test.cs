using Microsoft.ClearScript;
using System;
using System.IO;

namespace natsql
{
    sealed class Test
    {
        /// <summary>
        /// 调试命令行参数：-i 5 -t natsql.test.json
        /// </summary>
        /// <param name="flags"></param>
        public static void Run(Flags flags)
        {
            // 1.解析 natsql.yaml
            var config = Config.Parse(flags.Config);

            // 2.初始化配置
            var n = config.Init(0, flags.CreateInterval);
            if (n == 0) return;

            // 3.执行 natsql.js
            foreach (var item in Config.Items)
            {
                // test json data
                string testFile = $"{item.Dir}/{flags.Test}";
                if (!File.Exists(testFile)) continue;
                string testJson = File.ReadAllText(testFile);
                Console.WriteLine("[{0:T}] {1} > test json file: {2}", DateTime.Now, item.Subject, testFile);

                try
                {
                    // test js variable
                    //item.JS.Execute(@"console.log('config:',config)");
                    // test js function
                    var res = item.Invoke(testJson);
                    if (!(res is Undefined))
                    {
                        // execute sql command
                        if ("String" == res.GetType().Name && res.ToString().Length >= 20)
                            res = item.JS.Database.x(res) + " records affected database";
                        Console.Write(@"[{0:T}] {1} > return: ", DateTime.Now, item.Subject);
                        Console.WriteLine(res);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"[{0:T}] {1} > error: {2}", DateTime.Now, item.Subject, ex.Message);
                }
            }

            Console.WriteLine(@"[{0:T}] press [Ctrl+C] to quit...", DateTime.Now);

            Exit.Action = () =>
            {
                foreach (var item in Config.Items) item.Close().JsHandler?.Wait(true);
                //Config.JsCronScheduler.Shutdown();
                Console.WriteLine(@"[{0:T}] run finished.", DateTime.Now);
                QuartzHelper.Scheduler?.Shutdown();
                Environment.Exit(0);
            };

            Exit.Wait();
        }
    }
}
