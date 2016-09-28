using Common.Logging;
using Quartz;

namespace Lghui.Framework.Quzart
{
    public class TriggerListener : ITriggerListener
    {
        protected ILog Logger { get; } = LogManager.GetLogger("JobsLog");

        public string Name => "TriggerListener";

        /// <summary>
        /// Called by the <see cref="IScheduler" /> when a <see cref="ITrigger" />
        /// has fired, and it's associated <see cref="IJobDetail" />
        /// is about to be executed.
        /// <para>
        /// It is called before the <see cref="VetoJobExecution" /> method of this
        /// interface.
        /// </para>
        /// </summary>
        /// <param name="trigger">The <see cref="ITrigger" /> that has fired.</param>
        /// <param name="context">
        ///     The <see cref="IJobExecutionContext" /> that will be passed to the <see cref="IJob" />'s<see cref="IJob.Execute" /> method.
        /// </param>
        public void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
           
        }

        /// <summary>
        /// Called by the <see cref="IScheduler"/> when a <see cref="ITrigger"/>
        /// has fired, and it's associated <see cref="IJobDetail"/>
        /// is about to be executed.
        /// <para>
        /// It is called after the <see cref="TriggerFired"/> method of this
        /// interface.  If the implementation vetoes the execution (via
        /// returning <see langword="true" />), the job's execute method will not be called.
        /// </para>
        /// </summary>
        /// <param name="trigger">The <see cref="ITrigger"/> that has fired.</param>
        /// <param name="context">The <see cref="IJobExecutionContext"/> that will be passed to
        /// the <see cref="IJob"/>'s<see cref="IJob.Execute"/> method.</param>
        /// <returns>Returns true if job execution should be vetoed, false otherwise.</returns>
        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }

        /// <summary>
		/// Called by the <see cref="IScheduler" /> when a <see cref="ITrigger" />
		/// has misfired.
		/// <para>
		/// Consideration should be given to how much time is spent in this method,
		/// as it will affect all triggers that are misfiring.  If you have lots
		/// of triggers misfiring at once, it could be an issue it this method
		/// does a lot.
		/// </para>
		/// </summary>
		/// <param name="trigger">The <see cref="ITrigger" /> that has misfired.</param>
        public void TriggerMisfired(ITrigger trigger)
        {
            
        }

        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {
           
        }
    }
}
