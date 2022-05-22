using Quartz;
using Quartz.Impl;

namespace TradeBot_demo.Services
{
    public class Scheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Job>().Build();

            ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("trigger", "group")     
                .StartNow()                            
                .WithSimpleSchedule(x => x            
                    .WithIntervalInSeconds(1)
                    .RepeatForever())                   
                .Build();                               

            await scheduler.ScheduleJob(job, trigger);        
        }
    }
}
