using System.Collections.Generic;
using System.Text;
using Lghui.SmartQQ.Enum.Poll2;
using Lghui.SmartQQ.Enum.SendBuddyMsg2;

namespace Lghui.SmartQQ.Model.SendBuddyMsg2
{
    public class SendModel
    {
        /// <summary>
        /// 信息类型 message好友信息 group_message群信息
        /// </summary>
        public PollType PollType { get; set; } = PollType.Message;

        /// <summary>
        /// 接收方的uid 群信息就是group_uid
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 要发送的消息 按顺序add进去 
        /// </summary>
        public List<MsgModel> Msg { get; set; } = new List<MsgModel>();

        public string ToMsg()
        {
            var msgList = new List<string>();
            foreach (var msgModel in Msg)
            {
                switch (msgModel.Poll)
                {
                    case PollEnum.Text:
                        msgList.Add(msgModel.Msg);
                        break;
                    case PollEnum.Face:
                        msgList.Add($"[\"face\",{msgModel.Msg}]");
                        break;
                }
            }
            return string.Join(",", msgList);
        }
    }
}
