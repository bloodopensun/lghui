using System.Collections.Generic;
using Lghui.Framework.Expand;
using Lghui.SmartQQ.Enum.Poll2;
using Lghui.SmartQQ.Enum.SendAllMsg2;

namespace Lghui.SmartQQ.Model.SendAllMsg2
{
    public class SendModel
    {
        /// <summary>
        /// 优雅的初始化
        /// </summary>
        public static SendModel Build => new SendModel();

        /// <summary>
        /// 信息类型 message好友信息 group_message群信息
        /// </summary>
        public PollType PollType { get; set; } = PollType.message;

        /// <summary>
        /// 接收方的uid 群信息就是group_uid
        /// </summary>
        public long Uid { get; set; }

        /// <summary>
        /// 字体
        /// </summary>
        public FontModel Font { get; } = new FontModel();

        /// <summary>
        /// 要发送的消息 按顺序add进去 
        /// </summary>
        private List<object> MsgList { get; } = new List<object>();

        public SendModel Send(PollEnum poll, object msg)
        {
            switch (poll)
            {
                default:
                case PollEnum.Text:
                    MsgList.Add(msg);
                    break;
                case PollEnum.Face:
                    MsgList.Add(new[]
                        {
                            "face",
                            msg
                        });
                    break;
            }
            return this;
        }

        public string BuildMsg()
        {
            MsgList.Add(Font);
            return MsgList.ToJson();
        }
    }
}
