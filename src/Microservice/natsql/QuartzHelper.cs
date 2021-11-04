using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace natsql
{
    /// <summary>
    /// 定时任务 Quartz Helper
    /// </summary>
    public class QuartzHelper
    {
        /// <summary>
        /// 定时任务调度器
        /// </summary>
        public static IScheduler Scheduler;
        public static ISchedulerFactory SchedulerFactory;
        private static int triggerPriority = 0;
        private const string groupName = "default";
        private static readonly Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>> jobs = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>();

        public static ISchedulerFactory Create(string instanceName = "natsql", int impl = 0)
        {
            if (impl == 0)
            {
                // Creates an in memory job store (Quartz.Simpl.RAMJobStore)
                DirectSchedulerFactory.Instance.CreateVolatileScheduler(Environment.ProcessorCount);
                return DirectSchedulerFactory.Instance;
            }

            // quartz.config
            var props = new NameValueCollection
                {
                   { "quartz.scheduler.instanceName", instanceName },
                   { "quartz.threadPool.type", "Quartz.Simpl.SimpleThreadPool, Quartz" },
                   { "quartz.threadPool.threadCount", "10" },
                   { "quartz.threadPool.threadPriority", "Normal" },

                   { "quartz.plugin.xml.type", "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz.Plugins" },
                   //{ "quartz.plugin.xml.fileNames", "~/quartz_jobs.xml" },

                   //{ "quartz.serializer.type", "binary" },
                };

            return new StdSchedulerFactory(props);
        }

        /// <summary>
        /// 初始化调度器
        /// </summary>
        /// <returns></returns>
        public static async Task Init(string instanceName = "natsql", int impl = 0)
        {
            try
            {
                Scheduler = await Create(instanceName, impl).GetScheduler();
                await Scheduler.Start();
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 运行调度器任务
        /// </summary>
        /// <returns></returns>
        public static async Task Run()
        {
            try
            {
                await Scheduler.ScheduleJobs(jobs, true);
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 关闭调度器任务
        /// </summary>
        /// <returns></returns>
        public static async Task Shutdown()
        {
            try
            {
                await Scheduler.Shutdown();
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <typeparam name="T">任务类型IJob</typeparam>
        /// <param name="jobName">任务名</param>
        /// <param name="interval">运行间隔时间/秒;最小为1秒</param>
        /// <param name="period">等待启动时间/秒;-1为马上启动</param>
        /// <param name="repeatTime">重复次数;-1为永远运行</param>
        /// <param name="endAt">在指定时间后结束/秒;0为不指定结束时间,默认值0</param>
        public static void Add<T>(string jobName, int interval = 1, int period = -1, int repeatTime = -1, int endAt = 0, JobDataMap newJobDataMap = null, string group = groupName) where T : IJob
        {
            try
            {
                Interlocked.Increment(ref triggerPriority);

                if (interval <= 0)
                {
                    interval = 1;
                }
                if (period < -1)
                {
                    period = -1;
                }
                if (repeatTime < -1)
                {
                    repeatTime = -1;
                }
                if (endAt < 0)
                {
                    endAt = -1;
                }

                var builder = JobBuilder.Create<T>().WithIdentity(jobName, group);
                if (newJobDataMap != null) builder.UsingJobData(newJobDataMap);
                IJobDetail job = builder.Build();

                var triggerBuilder = TriggerBuilder.Create().WithIdentity(jobName, group);

                if (period == -1)
                {
                    triggerBuilder = triggerBuilder.StartNow();
                }
                else
                {
                    DateTimeOffset dateTimeOffset = DateTimeOffset.Now.AddSeconds(period);
                    triggerBuilder = triggerBuilder.StartAt(dateTimeOffset);
                }
                if (endAt > 0)
                {
                    triggerBuilder = triggerBuilder.EndAt(new DateTimeOffset(DateTime.Now.AddSeconds(endAt)));
                }

                if (repeatTime == -1)
                {
                    triggerBuilder = triggerBuilder.WithSimpleSchedule(x => x.WithIntervalInSeconds(interval).RepeatForever());
                }
                else
                {
                    triggerBuilder = triggerBuilder.WithSimpleSchedule(x => x.WithIntervalInSeconds(interval).WithRepeatCount(repeatTime));
                }

                ITrigger trigger = triggerBuilder.WithPriority(triggerPriority).Build();

                jobs.Add(job, new HashSet<ITrigger>() { trigger });
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <typeparam name="T">任务类型IJob</typeparam>
        /// <param name="jobName">任务名</param>
        /// <param name="cronExpress">cron表达式</param>
        public static void Add<T>(string jobName, string cronExpress, JobDataMap newJobDataMap = null, string group = groupName) where T : IJob
        {
            try
            {
                Interlocked.Increment(ref triggerPriority);

                var builder = JobBuilder.Create<T>().WithIdentity(jobName, group);
                if (newJobDataMap != null) builder.UsingJobData(newJobDataMap);
                IJobDetail job = builder.Build();

                ITrigger trigger = TriggerBuilder.Create()
                   .WithIdentity(jobName, group)
                   .WithCronSchedule(cronExpress)
                   .ForJob(job)
                   .StartNow()
                   .Build();

                jobs.Add(job, new HashSet<ITrigger>() { trigger });
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <typeparam name="T">任务类型IJob</typeparam>
        /// <param name="jobName">任务名</param>
        /// <param name="time"></param>
        /// <param name="json"></param>
        /// <param name="group"></param>
        public static void Add<T>(string jobName, long time, string json = null, string group = groupName) where T : IJob
        {
            try
            {
                var builder = JobBuilder.Create<T>().WithIdentity(jobName, group);
                if (!string.IsNullOrEmpty(json)) builder.UsingJobData("json", json);
                IJobDetail job = builder.Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity(jobName, group)
                    .ForJob(job)
                    .StartAt(DateTimeOffset.FromUnixTimeSeconds(time))
                    .Build();

                jobs.Add(job, new HashSet<ITrigger>() { trigger });
            }
            catch (SchedulerException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <typeparam name="T">任务类型IJob</typeparam>
        /// <param name="jobName">任务名</param>
        /// <param name="startTime">执行时间点</param>
        /// <returns></returns>
        public static Tuple<IJobDetail, ITrigger> New<T>(string jobName, DateTime startTime, JobDataMap newJobDataMap = null, string group = groupName) where T : IJob
        {
            var period = (DateTime.Now - startTime).TotalSeconds;
            if (period < 10) period = 10;

            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow.AddSeconds(period);

            var builder = JobBuilder.Create<T>().WithIdentity(jobName, group);
            if (newJobDataMap != null) builder.UsingJobData(newJobDataMap);
            IJobDetail job = builder.Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(jobName, group)
                .ForJob(job)
                .StartAt(dateTimeOffset)
                .Build();

            return new Tuple<IJobDetail, ITrigger>(job, trigger);
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <typeparam name="T">任务类型IJob</typeparam>
        /// <param name="jobName">任务名</param>
        /// <param name="cronExpress">cron表达式</param>
        /// <returns></returns>
        public static Tuple<IJobDetail, ITrigger> New<T>(string jobName, string cronExpress, JobDataMap newJobDataMap = null, string group = groupName) where T : IJob
        {
            var builder = JobBuilder.Create<T>().WithIdentity(jobName, group);
            if (newJobDataMap != null) builder.UsingJobData(newJobDataMap);
            IJobDetail job = builder.Build();

            ITrigger trigger = TriggerBuilder.Create()
               .WithIdentity(jobName, group)
               .WithCronSchedule(cronExpress)
               .ForJob(job)
               .StartNow()
               .Build();

            return new Tuple<IJobDetail, ITrigger>(job, trigger);
        }


        private static async Task<ITrigger> FindTrigger(string jobName, string group = groupName)
        {
            List<JobKey> jobKeys = Scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(group)).Result.ToList();
            if (jobKeys == null || jobKeys.Count() == 0)
                return null;

            JobKey jobKey = jobKeys.Where(s => Scheduler.GetTriggersOfJob(s).Result.Any(x => (x as CronTriggerImpl).Name == jobName)).FirstOrDefault();
            if (jobKey == null)
                return null;

            var triggers = await Scheduler.GetTriggersOfJob(jobKey);
            return triggers?.Where(x => (x as CronTriggerImpl).Name == jobName).FirstOrDefault();
        }

        public static async Task Delete(string jobName, string group = groupName)
        {
            var trigger = await FindTrigger(jobName, group);
            if (trigger == null)
                return;

            await Scheduler.PauseTrigger(trigger.Key);
            await Scheduler.UnscheduleJob(trigger.Key);
            await Scheduler.DeleteJob(trigger.JobKey);
        }

        public static async Task Pause(string jobName, string group = groupName)
        {
            var trigger = await FindTrigger(jobName, group);
            if (trigger == null)
                return;

            await Scheduler.PauseTrigger(trigger.Key);
        }

        public static async Task Resume(string jobName, string group = groupName)
        {
            var trigger = await FindTrigger(jobName, group);
            if (trigger == null)
                return;

            await Scheduler.ResumeTrigger(trigger.Key);
        }


        ///// <summary>
        ///// 获取所有的作业
        ///// </summary>
        ///// <param name="schedulerFactory"></param>
        ///// <returns></returns>
        //public static async Task<List<TaskOptions>> Jobs(this ISchedulerFactory schedulerFactory)
        //{
        //    List<TaskOptions> list = new List<TaskOptions>();
        //    try
        //    {
        //        var scheduler = await schedulerFactory.GetScheduler();
        //        var groupsNames = await scheduler.GetJobGroupNames();
        //        foreach (var groupName in groupsNames)
        //        {
        //            foreach (var jobKey in await scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName)))
        //            {
        //                TaskOptions taskOptions = _taskList.Where(x => x.GroupName == jobKey.Group && x.TaskName == jobKey.Name).FirstOrDefault();
        //                if (taskOptions == null) continue;

        //                var triggers = await scheduler.GetTriggersOfJob(jobKey);
        //                foreach (ITrigger trigger in triggers)
        //                {
        //                    DateTimeOffset? dateTimeOffset = trigger.GetPreviousFireTimeUtc();
        //                    if (dateTimeOffset != null)
        //                    {
        //                        taskOptions.LastRunTime = Convert.ToDateTime(dateTimeOffset.ToString());
        //                    }
        //                    else
        //                    {
        //                        var runlog = FileQuartz.GetJobRunLog(taskOptions.TaskName, taskOptions.GroupName, 1, 2);
        //                        if (runlog.Count > 0)
        //                        {
        //                            DateTime.TryParse(runlog[0].BeginDate, out DateTime lastRunTime);
        //                            taskOptions.LastRunTime = lastRunTime;
        //                        }
        //                    }
        //                }
        //                list.Add(taskOptions);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TextFile.WriteStartLog("获取作业异常：" + ex.Message + ex.StackTrace);
        //    }
        //    return list;
        //}

    }
}
