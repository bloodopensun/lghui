using Lghui.SmartQQ.Enum.SendBuddyMsg2;

namespace Lghui.SmartQQ.Model.SendBuddyMsg2
{
    public class MsgModel
    {
        /// <summary>
        /// 信息类型  text文本  face表情
        /// </summary>
        public PollEnum Poll { get; set; } = PollEnum.Text;

        /// <summary>
        /// 信息内容 文本直接文本  face传face代码  换行\n   传text类型
        /// </summary>
        public object Msg { get; set; }
    }
}
