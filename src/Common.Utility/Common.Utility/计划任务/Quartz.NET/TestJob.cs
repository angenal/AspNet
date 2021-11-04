using Quartz;
using System.Threading.Tasks;

namespace Common.Utility.Job
{
    public class TestJob : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            //这里写任务逻辑
            return Task.FromResult(0);
        }
    }
}
