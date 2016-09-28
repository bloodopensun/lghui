using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Lghui.Framework.OpenHttp.Enum;

namespace Lghui.Framework.OpenHttp
{
    /// <summary>
    /// Http头信息
    /// </summary>
    public class HttpHead
    {

        /// <summary>
        /// 初始化HttpHread
        /// </summary>
        public static HttpHead Builder => new HttpHead();

        #region 请求头

        /// <summary>
        /// 请求的Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 希望接受的数据类型,默认text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
        /// </summary>
        public string Accept { get; set; } = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

        /// <summary>
        /// 自动重定向
        /// </summary>
        public bool AllowAutoRedirect { get; set; } = true;

        /// <summary>
        /// 请求的参数集合
        /// </summary>
        public NameValueCollection Data { get; set; } = new NameValueCollection();

        /// <summary>
        /// 添加请求参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">值</param>
        /// <returns>HttpHead</returns>
        public HttpHead AddData(string key, string value)
        {
            Data.Add(key, value);
            return this;
        }

        /// <summary>
        /// 上传的文件
        /// </summary>
        public List<Tuple<string, string, byte[]>> Files { get; } = new List<Tuple<string, string, byte[]>>();

        /// <summary>
        /// 添加上传文件,key默认为c,并自动设置ContentType为Stream,Method为Post
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public HttpHead AddFile(string fileName, byte[] file)
        {
            return AddFile("filename", fileName, file);
        }

        /// <summary>
        /// 添加上传文件,并自动设置ContentType为Stream,Method为Post
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件流</param>
        /// <returns>HttpHead</returns>
        public HttpHead AddFile(string key, string fileName, byte[] file)
        {
            Method = Method.Post;
            ContentType = ContentType.Stream;
            Files.Add(Tuple.Create(key, fileName, file));
            return this;
        }

        /// <summary>
        /// Post数据方式
        /// </summary>
        public ContentType ContentType { get; set; } = ContentType.Default;

        /// <summary>
        /// 是否开启Cookie,默认开启
        /// </summary>
        public bool CookieState { get; set; } = true;

        /// <summary>
        /// 请求头
        /// </summary>
        public WebHeaderCollection RequestHeaders { get; } = new WebHeaderCollection { { "Accept-Encoding", "gzip,deflate" }, { "Accept-Language", "zh-CN,zh;q=0.8" } };

        /// <summary>
        /// 添加请求头
        /// </summary>
        /// <param name="key">Http头Key</param>
        /// <param name="value">值</param>
        /// <returns>HttpHead</returns>
        public HttpHead AddRequestHeader(string key, string value)
        {
            RequestHeaders.Add(key, value);
            return this;
        }

        /// <summary>
        /// 覆盖请求头
        /// </summary>
        /// <param name="key">Http头Key</param>
        /// <param name="value">值</param>
        /// <returns>HttpHead</returns>
        public HttpHead SetRequestHeader(string key, string value)
        {
            RequestHeaders.Set(key, value);
            return this;
        }

        /// <summary>
        /// 删除请求头
        /// </summary>
        /// <param name="key">Http头Key</param>
        /// <returns>HttpHead</returns>
        public HttpHead DelRequestHeader(string key)
        {
            RequestHeaders.Remove(key);
            return this;
        }

        /// <summary>
        /// 设置ClientIp
        /// </summary>
        public string ClientIp { get { return RequestHeaders["Client-Ip"]; } set { RequestHeaders.Set("Client-Ip", value); } }

        /// <summary>
        /// 设置RemoteAddr
        /// </summary>
        public string RemoteAddr { get { return RequestHeaders["RemoteAddr"]; } set { RequestHeaders.Set("RemoteAddr", value); } }

        /// <summary>
        /// 设置XForwardedFor
        /// </summary>
        public string XForwardedFor { get { return RequestHeaders["X-Forwarded-For"]; } set { RequestHeaders.Set("X-Forwarded-For", value); } }

        /// <summary>
        /// 同时设置ClientIp,RemoteAddr,XForwardedFor
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public HttpHead Ip(string ip)
        {
            ClientIp = ip;
            RemoteAddr = ip;
            XForwardedFor = ip;
            return this;
        }

        /// <summary>
        /// 支持的编码类型的,默认支持gzip,deflate
        /// </summary>
        public string AcceptEncoding { get { return RequestHeaders["Accept-Encoding"]; } set { RequestHeaders.Set("Accept-Encoding", value); } }

        /// <summary>
        /// 支持的语言类型,默认zh-CN,zh;q=0.8
        /// </summary>
        public string Acceptlanguange { get { return RequestHeaders["Accept-Language"]; } set { RequestHeaders.Set("Accept-Language", value); } }

        /// <summary>
        /// 普通/Ajax等异步请求,默认为普通
        /// </summary>
        public string XRequestedWith { get { return RequestHeaders["Accept-Language"]; } set { RequestHeaders.Set("X-Requested-With", value); } }

        /// <summary>
        /// 请求的Origin
        /// </summary>
        public string Origin { get { return RequestHeaders["Origin"]; } set { RequestHeaders.Set("Origin", value); } }

        /// <summary>
        /// 请求的Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 是否建立持久性连接,true
        /// </summary>
        public bool KeepAlive { get; set; } = true;

        /// <summary>
        /// 自动重定向的次数,默认50
        /// </summary>
        public int MaximumAutomaticRedirections { get; set; } = 50;

        /// <summary>
        /// 请求方式,默认Get
        /// </summary>
        public Method Method { get; set; } = Method.Get;

        /// <summary>
        /// http协议版本 默认1.1
        /// </summary>
        public Version Version { get; set; } = HttpVersion.Version11;

        /// <summary>
        /// 代理 默认无
        /// </summary>
        public IWebProxy Proxy { get; set; } = null;

        /// <summary>
        /// 请求的Referer
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// 浏览器标识
        /// </summary>
        public string UserAgent { get; set; } = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";

        /// <summary>
        /// 固定端口代理
        /// </summary>
        public BindIPEndPoint BindIpEndPointDelegate { get; set; }
        #endregion

        /// <summary>
        /// 返回的头
        /// </summary>
        public WebHeaderCollection ResponseHeaders { get; set; }

        /// <summary>
        /// 返回的资源编码
        /// </summary>
        public Encoding Encod { get; set; }
    }
}
