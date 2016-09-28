using System;
using System.ComponentModel;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExpand
    {
        /// <summary>
        /// 获取枚举的DescriptionAttribute属性
        /// </summary>
        /// <param name="enumeration">枚举值</param>
        /// <returns>DescriptionAttribute属性</returns>
        public static string ToDescriptionName(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var memInfo = type.GetMember(enumeration.ToString());
            if (memInfo.Length <= 0) return enumeration.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumeration.ToString();
        }
    }
}
