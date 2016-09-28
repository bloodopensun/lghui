using System.Collections.Specialized;
using System.Net;
using Lghui.Framework.OpenHttp;
using Lghui.Framework.OpenHttp.Enum;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// HttpHead扩展
    /// </summary>
    public static class HttpHeadExpand
    {
        /// <summary>
        /// 设置Url扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="url">url</param>
        /// <returns>Head对象</returns>
        public static HttpHead Url(this HttpHead head, string url)
        {
            head.Url = url;
            return head;
        }

        public static HttpHead Data(this HttpHead head, NameValueCollection data)
        {
            head.Data = data;
            return head;
        }

        /// <summary>
        /// 设置Origin扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="origin">origin</param>
        /// <returns>HttpHead</returns>
        public static HttpHead Origin(this HttpHead head, string origin)
        {
            head.Origin = origin;
            return head;
        }

        /// <summary>
        /// 设置Host扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="host">host</param>
        /// <returns>HttpHead</returns>
        public static HttpHead Host(this HttpHead head, string host)
        {
            head.Host = host;
            return head;
        }

        /// <summary>
        /// 设置Method扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="method">method</param>
        /// <returns>HttpHead</returns>
        public static HttpHead Method(this HttpHead head, Method method)
        {
            head.Method = method;
            return head;
        }

        /// <summary>
        /// 设置Method扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <returns>HttpHead</returns>
        public static HttpHead MethodGet(this HttpHead head)
        {
            head.Method(OpenHttp.Enum.Method.Get);
            return head;
        }

        /// <summary>
        /// 设置Method扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <returns>HttpHead</returns>
        public static HttpHead MethodPost(this HttpHead head)
        {
            head.Method(OpenHttp.Enum.Method.Post);
            return head;
        }

        /// <summary>
        /// 设置Proxy扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="proxy">proxy</param>
        /// <returns>HttpHead</returns>
        public static HttpHead Proxy(this HttpHead head, IWebProxy proxy)
        {
            head.Proxy = proxy;
            return head;
        }

        /// <summary>
        /// 设置Host扩展
        /// </summary>
        /// <param name="head">Head对象</param>
        /// <param name="referer">referer</param>
        /// <returns>HttpHead</returns>
        public static HttpHead Referer(this HttpHead head, string referer)
        {
            head.Referer = referer;
            return head;
        }
    }
}
