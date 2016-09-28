using System;
using System.Net;
using System.Threading.Tasks;
using Common.Logging;
using Lghui.Framework.Expand;
using Lghui.Framework.OpenHttp;
using Lghui.Framework.OpenHttp.Enum;
using Quartz;

namespace Lghui.Quartz.Jobs
{
    [DisallowConcurrentExecution]
    public class DemoJob1111 : IJob
    {
        private readonly HttpClient _httpClicent = new HttpClient();
        protected ILog Logger { get; } = LogManager.GetLogger("JobsLog");
        #region IJob 成员


        public void Execute(IJobExecutionContext context)
        {
            Logger.Info(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff"));
            //var host = Dns.GetHostAddresses("www.10zz.cn");
            ////while (true)
            ////{
            //Parallel.For(int.MinValue, int.MaxValue, (i) =>
            //{
            //    var hread = HttpHead.Builder
            //    .Url($"http://{host[new Random().Next(0, int.MaxValue) % host.Length]}/home/addcomment")
            //    .Host("www.10zz.cn")
            //    .Method(Method.Post)
            //    .AddData("articleid", new Random().Next(1, 189).ToString())
            //    .AddData("username", new Random().Next(1, int.MaxValue).ToString())
            //    .AddData("content", new Random().Next(1, int.MaxValue).ToString());

            //    var b = _httpClicent.Load(ref hread).ToString(hread.Encod);

            //    Logger.Info(b.Length);
            //});
            ////}
        }

        #endregion
    }
}
