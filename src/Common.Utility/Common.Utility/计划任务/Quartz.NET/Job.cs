using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using System;

namespace Common.Utility.Job
{
    public static class Job
    {
        static Job()
        {
            XMLSchedulingDataProcessor xMLSchedulingDataProcessor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
            IScheduler scheduler = (new StdSchedulerFactory()).GetScheduler().GetAwaiter().GetResult();
            xMLSchedulingDataProcessor.ProcessFileAndScheduleJobs( AppDomain.CurrentDomain.BaseDirectory+"/quartz_jobs.xml", scheduler);
            scheduler.Start();
        }
        public static void Start()
        {
        }
    }
}
