using SqlSugar;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SqlSugarHelper
{
    public sealed class Db
    {
        // <add name="Demo" connectionString="Data Source=.;Initial Catalog=Demo;Persist Security Info=True;User ID=sa;Password=123456;Max Pool Size=30;Min Pool Size=10;Connection TimeOut=10" providerName="System.Data.SqlClient"/>
        public static SqlSugarClient db = GetInstance("Demo");
        public static SqlSugarClient NewInstance(string ConnectionName)
        {
            return GetInstance(ConnectionName);
        }
        static SqlSugarClient GetInstance(string ConnectionName)
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString,
            });
        }

        public static void First()
        {
            //Create all class
            string dir = Environment.CurrentDirectory.Replace("\\bin", "\\") + "SqlSugarDemo\\Models";
            if (0 == Directory.GetFiles(dir, "*.cs").Length) db.DbFirst.CreateClassFile(dir, "ConsoleApp1.SqlSugarDemo.Models");
        }

        public static void Test()
        {
            int count = 10000;
            var sw = new Stopwatch();

            Console.WriteLine();
            Console.WriteLine($"HKT缓存写入测试{count / 10000}万次");
            sw.Restart();
            Parallel.For(0, count, i =>
            {
                var d = NewInstance("Demo");
                var a = new HKT() { TKey = Guid.NewGuid().ToString(), TValue = Guid.NewGuid().ToString() };
                var result = d.Insertable(a).ExecuteCommand();
            });
            sw.Stop();
            Console.WriteLine($"耗时：{sw.ElapsedMilliseconds} ms");


            Console.WriteLine();
            Console.WriteLine($"LKT数据写入测试{count / 10000}万次");
            sw.Start();
            Parallel.For(0, count, i =>
            {
                var d = NewInstance("Demo");
                var a = new LKT() { TKey = Guid.NewGuid().ToString(), TValue = Guid.NewGuid().ToString() };
                var result = d.Insertable(a).ExecuteCommand();
            });
            sw.Stop();
            Console.WriteLine($"耗时：{sw.ElapsedMilliseconds} ms");


            Console.WriteLine();
            string dir = Environment.CurrentDirectory + "\\tmp\\";
            Console.WriteLine($"File缓存写入测试{count / 10000}万次");
            sw.Restart();
            Parallel.For(0, count, i =>
            {
                var a = new HKT() { TKey = Guid.NewGuid().ToString(), TValue = Guid.NewGuid().ToString() };
                File.WriteAllText(dir + a.TKey + ".json", Newtonsoft.Json.JsonConvert.SerializeObject(a));
            });
            sw.Stop();
            Console.WriteLine($"耗时：{sw.ElapsedMilliseconds} ms");

        }

        /// <summary>
        /// 查询Task耗时
        /// </summary>
        public static void TestTasks()
        {
            var results = new List<string>();
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine();
            int totalPage = 5, pageSize = 10, totalNumber = 0;
            var pages = Enumerable.Range(1, totalPage).ToList();
            pages.ForEach(i =>
            {
                var d = NewInstance("Demo");
                var result = d.Queryable<LKT>().Select(a => a).ToPageList(i, pageSize, ref totalNumber);
                results.AddRange(result.Select(o => o.TKey));
            });
            sw.Stop();
            Console.WriteLine($"不用Task耗时：{sw.ElapsedMilliseconds} ms");
            Console.WriteLine(string.Join(",", results));

            results.Clear();
            sw.Restart();
            Console.WriteLine();
            results = SelectSimpleTask(pages, pageSize, totalNumber);
            sw.Stop();
            Console.WriteLine($"简单Task1耗时：{sw.ElapsedMilliseconds} ms");
            Console.WriteLine(string.Join(",", results));

            results.Clear();
            sw.Restart();
            Console.WriteLine();
            results = SelectParallelTask(pages, pageSize, totalNumber);
            sw.Stop();
            Console.WriteLine($"并发Task2耗时：{sw.ElapsedMilliseconds} ms");
            Console.WriteLine(string.Join(",", results));

        }
        /// <summary>
        /// 简单Task1查询
        /// </summary>
        private static List<string> SelectSimpleTask(List<int> pages, int pageSize, int totalNumber = 0, TimeSpan? timeout = null)
        {
            var results = new List<string>();
            var tasks = new List<Task<List<LKT>>>();
            var timeoutDefault = TimeSpan.FromSeconds(3);
            var cancellationTokenSource = new CancellationTokenSource(timeout ?? timeoutDefault);
            var taskFactory = new TaskFactory(cancellationTokenSource.Token);
            pages.ForEach(i =>
            {
                var task = taskFactory.StartNew(n =>
                {
                    var d = NewInstance("Demo");
                    if (cancellationTokenSource.IsCancellationRequested) cancellationTokenSource.Cancel();
                    var result = d.Queryable<LKT>().Select(a => a).ToPageList((int)n, pageSize, ref totalNumber);
                    return result;
                }, i);
                tasks.Add(task);
                task.ConfigureAwait(false);
            });
            Task.WaitAll(tasks.ToArray(), timeout ?? timeoutDefault);
            tasks.ForEach(task => { if (task.Result != null) results.AddRange(task.Result.Select(o => o.TKey)); });
            return results;
        }
        /// <summary>
        /// 并发Task2查询
        /// </summary>
        private static List<string> SelectParallelTask(List<int> pages, int pageSize, int totalNumber = 0, TimeSpan? timeout = null)
        {
            var results = new List<string>();
            var data = new ConcurrentDictionary<int, List<LKT>>();
            var timeoutDefault = TimeSpan.FromSeconds(3);
            var cancellationTokenSource = new CancellationTokenSource(timeout ?? timeoutDefault);
            Parallel.For(pages.First(), pages.Last() + 1, new ParallelOptions() { CancellationToken = cancellationTokenSource.Token, MaxDegreeOfParallelism = Environment.ProcessorCount }, (n, state) =>
             {
                 var d = NewInstance("Demo");
                 if (!cancellationTokenSource.IsCancellationRequested)
                 {
                     var result = d.Queryable<LKT>().Select(a => a).ToPageList(n, pageSize, ref totalNumber);
                     data.TryAdd(n, result);
                 }
             });
            pages.ForEach(i => { if (data.ContainsKey(i)) results.AddRange(data[i].Select(o => o.TKey)); });
            return results;
        }
    }
    
    ///<summary>
    ///
    ///</summary>
    public partial class HKT
    {
           public HKT(){
           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TKey {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TValue {get;set;}

    }
    ///<summary>
    ///
    ///</summary>
    public partial class LKT
    {
           public LKT(){
           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TKey {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TValue {get;set;}

    }
}
