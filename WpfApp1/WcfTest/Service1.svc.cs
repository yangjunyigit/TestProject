using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.ApplicationServices;
using System.Web.Services.Description;

namespace WcfTest
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            ApplicationServicesHostFactory f = new ApplicationServicesHostFactory();

            Task.Run(async () => {
                StdSchedulerFactory fac = new StdSchedulerFactory();
                IScheduler scd = await fac.GetScheduler();
                await scd.Start();

                IJobDetail jobDetail = JobBuilder.Create<HelloJob>().WithIdentity("job1", "group1").Build();
                ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger`", "group1").StartNow()
                .WithSimpleSchedule(x=>x.WithIntervalInSeconds(60).RepeatForever()).Build();

                await scd.ScheduleJob(jobDetail, trigger);
                
                await Task.Delay(TimeSpan.FromSeconds(60));

                await scd.Shutdown();
            });

            //ILoggerProvider

            return composite;
        }
    }

    public class LogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return (level,func ,exception,parameters) => { 
            
                if(level >= LogLevel.Info && func!=null )
                {
                    Console.WriteLine();
                }
                return true;
            };
        }

        public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }
    }
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("测试！！！");
        }
    }
}
