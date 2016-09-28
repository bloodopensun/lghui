using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lghui.Framework.Expand;
using Lghui.Framework.OpenHttp;
using Lghui.SmartQQ.Model;

namespace Lghui.SmartQQ
{
    public partial class SmartQQClient
    {
        #region 获取登录二维码
        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <returns>二维码</returns>
        public byte[] PtQrShow()
        {
            var head = HttpHead.Builder
                .MethodGet()
                .Url(PtQrShowUrl)
                .Referer(PtQrShowReferer)
                .Host(PtQrShowHost);
            var bytes = _httpClient.Load(ref head);
            return bytes;
        }
        #endregion

        #region 获取二维码状态
        /// <summary>
        /// 获取二维码状态
        /// 0登录成功
        /// 65已失效
        /// 66未失效
        /// 67认证中
        /// </summary>
        /// <param name="errMsg">状态信息</param>
        /// <returns>状态码</returns>
        public int PtQrLogin(out string errMsg)
        {
            var head = HttpHead.Builder
                .MethodGet()
                .Url(PtQrLoginUrl)
                .Referer(PtQrLoginReferer)
                .Host(PtQrLoginHost);

            var bytes = _httpClient.Load(ref head);

            var html = bytes.ToString(head.Encod);

            var reg = new Regex(@".*?\('(.*?)'.*?'(.*?)'.*?'(.*?)'.*?'(.*?)'.*?'(.*?)'.*?'(.*?)'\);");
            var ma = reg.Match(html);

            errMsg = ma.Groups[5].ToString();

            var status = int.Parse(ma.Groups[1].ToString());
            if (status != 0) return status;

            CheckSig(ma.Groups[3].ToString());
            return status;
        }

        /// <summary>
        /// 获取登录Cookie
        /// </summary>
        /// <param name="url">获取cookei的url</param>
        private void CheckSig(string url)
        {
            var reg = new Regex(@"http://(.*?)/");
            var ma = reg.Match(url);
            var host = ma.Groups[1].ToString();

            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Host(host);
            _httpClient.Load(ref head);
            GetVfWebqq();
        }

        /// <summary>
        /// 获取VfWebQq
        /// </summary>
        private void GetVfWebqq()
        {
            var url = string.Format(GetVfWebQQUrl, Ptwebqq, ClientId, DateTime.Now.ToTimeStamp());

            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetVfWebQQReferer)
                .Host(GetVfWebQQHost);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var vfwebqqModel = json.JsonToModel<SmartQQModel<Model.Vfwebqq.Result>>();
            VfwebqqModel = vfwebqqModel.Result;
            Login2();
        }

        /// <summary>
        /// 二次登录
        /// </summary>
        private void Login2()
        {
            var head = HttpHead.Builder
                .MethodPost()
                .Url(Login2Url)
                .Referer(Login2Referer)
                .Host(Login2Host)
                .Origin(Login2Origin)
                .AddData("r", new { ptwebqq = Ptwebqq, clientid = ClientId, psessionid = string.Empty, status = "online" }.ToJson());

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var login2Model = json.JsonToModel<SmartQQModel<Model.Login2.Result>>();
            Login2Model = login2Model.Result;
        }
        #endregion

        #region 获取/刷新好友列表
        /// <summary>
        /// 获取/刷新好友列表
        /// </summary>
        /// <returns>好友列表</returns>
        public Model.UserFriends2.Result GetUserFriends2()
        {
            var head = HttpHead.Builder
                .MethodPost()
                .Url(GetUserFriends2Url)
                .Referer(GetUserFriends2Referer)
                .Host(GetUserFriends2Host)
                .Origin(GetUserFriends2Origin)
                .AddData("r", new
                {
                    vfwebqq = VfwebqqModel.Vfwebqq,
                    hash = Gethash()
                }.ToJson());

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var userFriends2 = json.JsonToModel<SmartQQModel<Model.UserFriends2.Result>>();
            UserFriends2Model = userFriends2.Result;
            return UserFriends2Model;
        }
        #endregion

        #region 获取/刷新群列表
        /// <summary>
        /// 获取/刷新群列表
        /// </summary>
        /// <returns></returns>
        public Model.GroupNameListMask2.Result GetGroupNameListMask2()
        {
            var head = HttpHead.Builder
                .MethodPost()
                .Url(GetGroupNameListMask2Url)
                .Referer(GetGroupNameListMask2Referer)
                .Host(GetGroupNameListMask2Host)
                .Origin(GetGroupNameListMask2Origin)
                .AddData("r", new
                {
                    vfwebqq = VfwebqqModel.Vfwebqq,
                    hash = Gethash()
                }.ToJson());

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var groupNameListMask2 = json.JsonToModel<SmartQQModel<Model.GroupNameListMask2.Result>>();
            GroupNameListMask2Model = groupNameListMask2.Result;
            return GroupNameListMask2Model;
        }
        #endregion

        #region 获取/刷新讨论组列表
        /// <summary>
        /// 获取/刷新讨论组列表
        /// </summary>
        /// <returns></returns>
        public Model.DiscusList.Result GetDiscusList()
        {
            var url = string.Format(GetDiscusListUrl, ClientId, Login2Model.Psessionid, VfwebqqModel.Vfwebqq, DateTime.Now.ToTimeStamp());
            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetDiscusListReferer)
                .Host(GetDiscusListHost);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var discusList = json.JsonToModel<SmartQQModel<Model.DiscusList.Result>>();
            DiscusListModel = discusList.Result;
            return DiscusListModel;
        }
        #endregion

        #region 获取/刷新个人信息
        /// <summary>
        /// 获取/刷新个人信息
        /// </summary>
        /// <returns></returns>
        public Model.SelfInfo2.Result GetSelfInfo2()
        {
            var url = string.Format(GetSelfInfo2Url, DateTime.Now.ToTimeStamp());
            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetSelfInfo2Referer)
                .Host(GetSelfInfo2Host);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var selfInfo2 = json.JsonToModel<SmartQQModel<Model.SelfInfo2.Result>>();
            SelfInfo2Model = selfInfo2.Result;
            return SelfInfo2Model;
        }
        #endregion

        #region 获取/刷新在线列表
        /// <summary>
        /// 获取/刷新在线列表
        /// </summary>
        /// <returns></returns>
        public List<Model.OnlineBuddies2.Result> GetOnlineBuddies2()
        {
            var url = string.Format(GetOnlineBuddies2Url, VfwebqqModel.Vfwebqq, ClientId, Login2Model.Psessionid, DateTime.Now.ToTimeStamp());
            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetOnlineBuddies2Referer)
                .Host(GetOnlineBuddies2Host);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var onlineBuddies2 = json.JsonToModel<SmartQQModel<List<Model.OnlineBuddies2.Result>>>();
            OnlineBuddies2List = onlineBuddies2.Result;
            return OnlineBuddies2List;
        }
        #endregion

        #region 获取/刷新最近联系列表
        /// <summary>
        /// 获取/刷新最近联系列表
        /// </summary>
        /// <returns></returns>
        public List<Model.RecentList2.Result> GetRecentList2()
        {
            var head = HttpHead.Builder
                .MethodPost()
                .Url(RecentList2Url)
                .Referer(RecentList2Referer)
                .Host(RecentList2Host)
                .Origin(RecentList2Origin)
                .AddData("r", new
                {
                    vfwebqq = VfwebqqModel.Vfwebqq,
                    clientid = ClientId,
                    psessionid = Login2Model.Psessionid
                }.ToJson());

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var recentList2 = json.JsonToModel<SmartQQModel<List<Model.RecentList2.Result>>>();
            RecentList2List = recentList2.Result;
            return RecentList2List;
        }
        #endregion

        #region 心跳/消息等
        /// <summary>
        /// 心跳/消息等
        /// </summary>
        /// <returns></returns>
        public SmartQQModel<List<Model.Poll2.Result>> GetPoll2()
        {
            var head = HttpHead.Builder
                   .MethodPost()
                   .Url(Poll2Url)
                   .Referer(Poll2Referer)
                   .Host(Poll2Host)
                   .Origin(Poll2Origin)
                   .AddData("r", new
                   {
                       ptwebqq = Ptwebqq,
                       clientid = ClientId,
                       psessionid = Login2Model.Psessionid,
                       key = string.Empty
                   }.ToJson());

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var poll2 = json.JsonToModel<SmartQQModel<List<Model.Poll2.Result>>>();
            return poll2;
        }
        #endregion

        #region 获取/刷新群成员列表
        /// <summary>
        /// 获取/刷新群成员列表
        /// </summary>
        /// <param name="gcode">群code</param>
        /// <returns></returns>
        public Model.GroupInfoExt2.Result GetGroupInfoExt2(long gcode)
        {
            var url = string.Format(GetGroupInfoExt2Url, gcode, VfwebqqModel.Vfwebqq, DateTime.Now.ToTimeStamp());
            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetGroupInfoExt2Referer)
                .Host(GetGroupInfoExt2Host);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var model = json.JsonToModel<SmartQQModel<Model.GroupInfoExt2.Result>>();
            if (GroupInfoExt2.ContainsKey(gcode)) GroupInfoExt2[gcode] = model.Result;
            else GroupInfoExt2.Add(gcode, model.Result);
            return model.Result;
        }
        #endregion

        #region 获取/刷新讨论组成员列表
        /// <summary>
        /// 获取/刷新讨论组成员列表
        /// </summary>
        /// <param name="did">讨论组did</param>
        /// <returns></returns>
        public Model.DiscuInfo.Result GetDiscuInfo(long did)
        {
            var url = string.Format(GetDiscuInfoUrl, did, VfwebqqModel.Vfwebqq, ClientId, Login2Model.Psessionid, DateTime.Now.ToTimeStamp());
            var head = HttpHead.Builder
                .MethodGet()
                .Url(url)
                .Referer(GetDiscuInfoReferer)
                .Host(GetDiscuInfoHost);

            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
            var model = json.JsonToModel<SmartQQModel<Model.DiscuInfo.Result>>();
            if (DiscuInfo.ContainsKey(did)) DiscuInfo[did] = model.Result;
            else DiscuInfo.Add(did, model.Result);
            return model.Result;
        }
        #endregion

        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendBuddyMsg2(long uin)
        {
            var head = HttpHead.Builder
                .MethodPost()
                .Url(SendBuddyMsg2Url)
                .Referer(SendBuddyMsg2Referer)
                .Host(SendBuddyMsg2Host)
                .Origin(SendBuddyMsg2Origin)
                .AddData("r", new
                {
                    to = uin,
                    content = new object[]
                    {
                        1,
                        "" ,
                        new object[]
                        {
                            "font",
                            new
                            {
                                name = "宋体",
                                size = 10,
                                style = new []
                                {
                                    0,
                                    0,
                                    0
                                },
                                color = "000000"
                            }
                        }
                    },
                    face = 0,
                    clientid = ClientId,
                    msg_id = MsgId++,
                    psessionid = Login2Model.Psessionid
                }.ToJson());
            //{"to":406441720,"content":"[[\"Face\",3],\" \",[\"font\",{\"name\":\"宋体\",\"size\":10,\"style\":[0,0,0],\"color\":\"000000\"}]]","Face":0,"clientid":53999199,"msg_id":85260001,"psessionid":"8368046764001d636f6e6e7365727665725f77656271714031302e3133332e34312e383400001ad00000066b026e040015808a206d0000000a406172314338344a69526d0000002859185d94e66218548d1ecb1a12513c86126b3afb97a3c2955b1070324790733ddb059ab166de6857"}
            var bytes = _httpClient.Load(ref head);

            var json = bytes.ToString(head.Encod);
        }
    }
}
