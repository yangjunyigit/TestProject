using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;

namespace TestWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TestTask();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async void TestTask()
        {
            NameValueCollection props = new NameValueCollection();
            props.Add(name: "quartz.serializer.type", value: "binary");

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<HelloworldJob>().WithIdentity("myJob","qroup1").Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("myTrigger", "group1").StartNow().WithSimpleSchedule(x=>x.WithIntervalInSeconds(40)).Build();

            await sched.ScheduleJob(job, trigger);
        }
    }

    public class HelloworldJob : IJob
    {
        private readonly ILogger<Worker> _logger;

        public HelloworldJob(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() => { 
                _logger.LogInformation("hello world!!!"); 
                Task.Delay(1000);
            });
        }
    }
}
