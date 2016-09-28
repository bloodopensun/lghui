using System;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// Guid拓展
    /// </summary>
    public static class GuidExpand
    {
        /// <summary>
        /// 转换为32位Id
        /// </summary>
        /// <param name="guid">待转换的Guid</param>
        /// <returns>32位Id</returns>
        public static string ToId(this Guid guid)
        {
            return guid.ToString("n");
        }
    }
}
