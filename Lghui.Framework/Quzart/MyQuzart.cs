using System.Diagnostics;
using Lghui.Framework.Expand;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace Lghui.Framework.Quzart
{
    public static class MyQuzart
    {
        private static readonly ISchedulerFactory SchedulerFactory;
        public static readonly IScheduler Scheduler;

        static MyQuzart()
        {
            SchedulerFactory = new StdSchedulerFactory();
            Scheduler = SchedulerFactory.GetScheduler();
            TriggerListener triggerListener = new TriggerListener();
            Scheduler.ListenerManager.AddTriggerListener(triggerListener);
            JobListener jobListener = new JobListener();
            Scheduler.ListenerManager.AddJobListener(jobListener);
        }

        /// <summary>
        /// 开启所有任务
        /// </summary>
        public static void Start()
        {
            Scheduler.Start();
        }

        /// <summary>
        /// 结束所有任务
        /// 不能重新开启
        /// </summary>
        public static void Shutdown()
        {
            Scheduler.Shutdown(true);
        }

        /// <summary>
        /// 暂停所有任务
        /// 可以重新恢复
        /// </summary>
        public static void PauseAll()
        {
            Scheduler.PauseAll();
        }

        /// <summary>
        /// 恢复所有任务
        /// </summary>
        public static void Resume()
        {
            Scheduler.ResumeAll();
        }

        /// <summary>
        /// 清除所有任务
        /// </summary>
        public static void Clear()
        {
            Scheduler.Clear();
        }

        public static void a()
        {
            var groups = Scheduler.GetJobGroupNames();
            foreach (var group in groups)
            {
                var matcher = GroupMatcher<JobKey>.GroupEquals(group);
                var jobKeys = Scheduler.GetJobKeys(matcher);
                foreach (var jobKey in jobKeys)
                {
                    try
                    {
                        var job = Scheduler.GetJobDetail(jobKey);
                    }
                    catch (System.Exception)
                    {

                        //Scheduler.PauseJob(jobKey);
                        //Scheduler.ResumeJob(jobKey);
                    }
                }
            }
            groups = Scheduler.GetTriggerGroupNames();
            foreach (var group in groups)
            {
                var matcher = GroupMatcher<TriggerKey>.GroupEquals(group);
                var triggerKeys = Scheduler.GetTriggerKeys(matcher);
                foreach (var triggerKey in triggerKeys)
                {
                    var trigger = Scheduler.GetTrigger(triggerKey);
                    Debug.WriteLine(trigger.ToJson());

                }
            }

        }
    }
}
