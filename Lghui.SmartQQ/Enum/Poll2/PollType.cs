using System.ComponentModel;

namespace Lghui.SmartQQ.Enum.Poll2
{
    public enum PollType
    {
        /// <summary>
        /// 好友消息
        /// </summary>
        [Description("message")]
        Message,

        /// <summary>
        /// 群消息
        /// </summary>
        [Description("group_message")]
        GroupMessage,

        /// <summary>
        /// 讨论组消息
        /// </summary>
        [Description("DiscuMessage")]
        DiscuMessage,

        /// <summary>
        /// 好友系统消息
        /// </summary>
        [Description("system_message")]
        SystemMessage,

        /// <summary>
        /// 群系统消息
        /// </summary>
        [Description("sys_g_msg")]
        SysGMsg
    }
}
