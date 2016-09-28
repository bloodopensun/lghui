using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Lghui.Framework.Expand;
using Lghui.SmartQQ;
using Newtonsoft.Json.Linq;

namespace SmartQQ
{
    class Program
    {
        private static readonly SmartQQClient Qq = new SmartQQClient();
        static void Main(string[] args)
        {
            //获取验证码
            qrShow:
            var qrBytes = Qq.PtQrShow();
            PtQrShow(qrBytes.ToImage());

            //获取验证码状态
            while (true)
            {
                string errMsg;
                var status = Qq.PtQrLogin(out errMsg);
                Console.Title = errMsg;
                Thread.Sleep(1000);

                //失效重新获取
                if (status == 65)
                    goto qrShow;

                //成功跳出
                if (status == 0)
                    break;
            }

            Console.Clear();

            var friends = Qq.GetUserFriends2();

            var groups = Qq.GetGroupNameListMask2();

            var discus = Qq.GetDiscusList();

            var selfInfo = Qq.GetSelfInfo2();

            var onlineBuddies = Qq.GetOnlineBuddies2();

            var recentList = Qq.GetRecentList2();

            Console.Title = $"{selfInfo.Nick}   分组:{friends.Categories.Count}   好友:{friends.Friends.Count}   在线:{onlineBuddies.Count}   群:{groups.GnameList.Count}   讨论组:{discus.DnameList.Count}   最近:{recentList.Count}";

            while (true)
            {
                var poll = Qq.GetPoll2();
                switch (poll.Retcode)
                {
                    case 0:
                        if (null == poll.Result) continue;
                        Message(poll.Result);
                        break;
                    default:
                        Console.WriteLine(poll.ToJson());
                        break;
                }
            }
        }

        #region PtQrShow
        private static void PtQrShow(Image img)
        {
            #region Console
            Console.Title = @"SmartQQ";
            Console.WindowWidth = 33 * 2 + 5;
            Console.WindowHeight = 33 + 4;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            #endregion
            var sourcebm = new Bitmap(img);
            var str = new StringBuilder();
            str.AppendLine("███████████████████████████████████");
            for (var x = 0; x < sourcebm.Height; x += sourcebm.Height / 33)
            {
                str.Append("█");
                for (var y = 0; y < sourcebm.Width; y += sourcebm.Height / 33)
                {
                    var c = sourcebm.GetPixel(y, x);
                    str.Append(c.R == 0 && c.G == 0 && c.B == 0 ? "  " : "█");
                }
                str.AppendLine("█");
            }
            str.AppendLine("███████████████████████████████████");
            Console.Clear();
            Console.Write(str.ToString());
        }
        #endregion

        #region Message
        private static void Message(IEnumerable<Lghui.SmartQQ.Model.Poll2.Result> model)
        {
            foreach (var result in model)
            {
                var hread = new StringBuilder();
                var dateTime = DateTime.Now.ToString("HH:mm:ss");
                switch (result.PollType)
                {
                    case "message":
                        var info = GetUserFriends(result.Value.FromUin);
                        var marknames = Qq.UserFriends2Model.Marknames?.FirstOrDefault(c => c.Uin == result.Value.FromUin);
                        hread.AppendLine($"{(null == marknames ? info.Nick : marknames.Markname)} {dateTime}");
                        break;
                    case "group_message":
                        var gname = GetGroupNameListMask(result.Value.GroupCode);
                        var gmark = Qq.GroupNameListMask2Model.GmarkList?.FirstOrDefault(c => c.Uin == result.Value.GroupCode);
                        hread.AppendLine($"{(null == gmark ? gname.Name : gmark.MarkName)}");

                        var minfo = GetGroupInfoExt(gname.Code, result.Value.SendUin);
                        var card = Qq.GroupInfoExt2[gname.Code].Cards?.FirstOrDefault(c => c.Muin == result.Value.SendUin);
                        hread.AppendLine($"{(null == card ? minfo.Nick : card.Card)} {dateTime}");
                        break;
                    case "discu_message":
                        var dname = GetDiscusList(result.Value.Did);
                        hread.AppendLine($"{dname.Name}");

                        var meminfo = GetDiscuInfo(result.Value.Did, result.Value.SendUin);
                        hread.AppendLine($"{meminfo.Nick} {dateTime}");
                        break;
                    default:
                        hread.AppendLine(result.PollType);
                        break;
                }

                var msg = new StringBuilder();
                for (var i = 1; i < result.Value.Content.Count; i++)
                {
                    var content = result.Value.Content[i];
                    if (content is JArray)
                    {
                        var expression = Qq.Expression.FirstOrDefault(c => c.Key == content[1].ToString());
                        msg.Append($"[{(expression != null ? expression.Value : content[1].ToString())}]");
                    }
                    else
                    {
                        msg.Append(content);
                    }
                }
                hread.AppendLine(msg.ToString());
                Console.WriteLine(hread);
            }
        }
        private static Lghui.SmartQQ.Model.UserFriends2.Info GetUserFriends(long uin)
        {
            while (true)
            {
                if (Qq.UserFriends2Model?.Info?.FirstOrDefault(c => c.Uin == uin) != null)
                    return Qq.UserFriends2Model.Info.FirstOrDefault(c => c.Uin == uin);
                Qq.GetUserFriends2();
            }
        }

        public static Lghui.SmartQQ.Model.GroupNameListMask2.Gname GetGroupNameListMask(long gid)
        {
            while (true)
            {
                if (Qq.GroupNameListMask2Model?.GnameList?.FirstOrDefault(c => c.Gid == gid) != null)
                    return Qq.GroupNameListMask2Model.GnameList.FirstOrDefault(c => c.Gid == gid);
                Qq.GetGroupNameListMask2();
            }
        }

        public static Lghui.SmartQQ.Model.GroupInfoExt2.Minfo GetGroupInfoExt(long code, long uin)
        {
            while (true)
            {
                if (Qq.GroupInfoExt2.ContainsKey(code) && Qq.GroupInfoExt2[code]?.Minfo?.FirstOrDefault(c => c.Uin == uin) != null)
                    return Qq.GroupInfoExt2[code].Minfo.FirstOrDefault(c => c.Uin == uin);
                Qq.GetGroupInfoExt2(code);
            }
        }

        public static Lghui.SmartQQ.Model.DiscusList.Dname GetDiscusList(long did)
        {
            while (true)
            {
                if (Qq.DiscusListModel?.DnameList?.FirstOrDefault(c => c.Did == did) != null)
                    return Qq.DiscusListModel.DnameList?.FirstOrDefault(c => c.Did == did);
                Qq.GetDiscusList();
            }
        }

        public static Lghui.SmartQQ.Model.DiscuInfo.MemInfo GetDiscuInfo(long did, long uin)
        {
            while (true)
            {
                if (Qq.DiscuInfo.ContainsKey(did) && Qq.DiscuInfo[did]?.MemInfo?.FirstOrDefault(c => c.Uin == uin) != null)
                    return Qq.DiscuInfo[did].MemInfo.FirstOrDefault(c => c.Uin == uin);
                Qq.GetDiscuInfo(did);
            }
        } 
        #endregion
    }
}
