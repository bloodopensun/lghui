using System;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// Uri扩展
    /// </summary>
    public static class UriExpand
    {
        /// <summary>
        /// 转义Uri参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ToEscapeUri(this string url)
        {
            return Uri.EscapeUriString(url);
        }

        /// <summary>
        /// 转义整个Uri
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ToEscapeData(this string url)
        {
            return Uri.EscapeDataString(url);
        }


        /// <summary>
        /// 还原Uri转义
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ToUnescape(this string url)
        {
            return Uri.UnescapeDataString(url);
        }

    }
}