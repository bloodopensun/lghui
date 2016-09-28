using Common.Logging;
using Lghui.Framework.Expand;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Lghui.Framework.Quzart
{
    public class JobListener : IJobListener
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(JobListener));

        public string Name => "MyJobListenerSupport";
        /// <summary>
		/// Called by the <see cref="IScheduler" /> when a <see cref="IJobDetail" />
		/// is about to be executed (an associated <see cref="ITrigger" />
		/// has occurred).
		/// <para>
		/// This method will not be invoked if the execution of the Job was vetoed
		/// by a <see cref="ITriggerListener" />.
		/// </para>
		/// </summary>
		/// <seealso cref="JobExecutionVetoed(IJobExecutionContext)" />
		public void JobToBeExecuted(IJobExecutionContext context)
        {
            var jobDetailImpl = (JobDetailImpl)context.JobDetail;
            _logger.Info($"{jobDetailImpl.FullName}:执行开始");
        }

        /// <summary>
        /// Called by the <see cref="IScheduler" /> when a <see cref="IJobDetail" />
        /// was about to be executed (an associated <see cref="ITrigger" />
        /// has occurred), but a <see cref="ITriggerListener" /> vetoed it's 
        /// execution.
        /// </summary>
        /// <seealso cref="JobToBeExecuted(IJobExecutionContext)" />
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            var jobDetailImpl = (JobDetailImpl)context.JobDetail;
            _logger.Info($"{jobDetailImpl.FullName}:执行中断");
        }


        /// <summary>
        /// Called by the <see cref="IScheduler" /> after a <see cref="IJobDetail" />
        /// has been executed, and be for the associated <see cref="IOperableTrigger" />'s
        /// <see cref="IOperableTrigger.Triggered" /> method has been called.
        /// </summary>
        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            var jobDetailImpl = (JobDetailImpl)context.JobDetail;
            if (null == jobException) _logger.Info($"{jobDetailImpl.FullName}:执行结束");
            else _logger.Error($"{jobDetailImpl.FullName}\r\n{jobException.ToJson()}");
        }
    }
}
