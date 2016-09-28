using System;
using System.Runtime.InteropServices;
using System.Threading;
using Lghui.Framework.Quzart;
using Lghui.Quartz.Jobs;
using Quartz;

namespace Lghui.Quartz.Linux
{
    class Program
    {

        [DllImport("libc", SetLastError = true)]
        private static extern void signal(int sig, Action<int> func);

        private static bool _temp = true;

        static void Main()
        {
            //signal(2, CallBack);
            //signal(15, CallBack);

            MyQuzart.a();
            //MyQuzart.Clear();
            //var job = JobBuilder.Create<DemoJob1>()
            //       .WithIdentity("7", "代理IP")
            //       .Build();

            //var trigger = (ICronTrigger)TriggerBuilder.Create()
            //    .WithIdentity("7", "代理IP")
            //    .WithCronSchedule("*/1 * * * * ?")
            //    .Build();
            //MyQuzart.Scheduler.ScheduleJob(job, trigger);
            //MyQuzart.Scheduler.RescheduleJob(trigger.Key, trigger);

            MyQuzart.Start();
            while (_temp)
                Thread.Sleep(1000);
            MyQuzart.Shutdown();
        }

        private static void CallBack(int sig)
        {
            _temp = false;
        }
    }
}
