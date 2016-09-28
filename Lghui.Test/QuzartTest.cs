using Lghui.Framework.Expand;
using Lghui.Framework.OpenHttp;
using Lghui.Framework.Quzart;
using NUnit.Framework;

namespace Lghui.Test
{
    [TestFixture]
    class QuzartTest
    {
        [Test]
        public void Test()
        {
            HttpClient httpClient = new HttpClient();
            HttpHead head = HttpHead.Builder.Url("http://127.0.0.1:63342/browserConnection/buildInfo");
            byte[] bytes = httpClient.Load(ref head);
            string html = bytes.ToString(head.Encod);
        }
    }
}
