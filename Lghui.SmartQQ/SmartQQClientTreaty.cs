namespace Lghui.SmartQQ
{
    partial class SmartQQClient
    {
        #region 获取二维码
        private const string PtQrShowUrl = "https://ssl.ptlogin2.qq.com/ptqrshow?appid=501004106&e=0&l=M&s=5&d=72&v=4&t=0.774628123223505";
        private const string PtQrShowReferer = "https://ui.ptlogin2.qq.com/cgi-bin/login?daid=164&target=self&style=16&mibao_css=m_webqq&appid=501004106&enable_qlogin=0&no_verifyimg=1&s_url=http%3A%2F%2Fw.qq.com%2Fproxy.html&f_url=loginerroralert&strong_login=1&login_state=10&t=20131024001";
        private const string PtQrShowHost = "ssl.ptlogin2.qq.com";
        #endregion

        #region 获取二维码状态
        private const string PtQrLoginUrl = "https://ssl.ptlogin2.qq.com/ptqrlogin?webqq_type=10&remember_uin=1&login2qq=1&aid=501004106&u1=http%3A%2F%2Fw.qq.com%2Fproxy.html%3Flogin2qq%3D1%26webqq_type%3D10&ptredirect=0&ptlang=2052&daid=164&from_ui=1&pttype=1&dumy=&fp=loginerroralert&action=0-0-208117&mibao_css=m_webqq&t=undefined&g=1&js_type=0&js_ver=10176&login_sig=&pt_randsalt=0";
        private const string PtQrLoginReferer = "https://ui.ptlogin2.qq.com/cgi-bin/login?daid=164&target=self&style=16&mibao_css=m_webqq&appid=501004106&enable_qlogin=0&no_verifyimg=1&s_url=http%3A%2F%2Fw.qq.com%2Fproxy.html&f_url=loginerroralert&strong_login=1&login_state=10&t=20131024001";
        private const string PtQrLoginHost = "ssl.ptlogin2.qq.com";
        #endregion

        #region 获取VfWebQQ
        private const string GetVfWebQQUrl = "http://s.web2.qq.com/api/getvfwebqq?ptwebqq={0}&clientid={1}&psessionid=&t={2}";
        private const string GetVfWebQQReferer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetVfWebQQHost = "s.web2.qq.com";
        #endregion

        #region 二次登录
        private const string Login2Url = "http://d1.web2.qq.com/channel/login2";
        private const string Login2Referer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string Login2Host = "d1.web2.qq.com";
        private const string Login2Origin = "http://d1.web2.qq.com";
        #endregion

        #region 获取好友列表
        private const string GetUserFriends2Url = "http://s.web2.qq.com/api/get_user_friends2";
        private const string GetUserFriends2Referer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetUserFriends2Host = "s.web2.qq.com";
        private const string GetUserFriends2Origin = "http://s.web2.qq.com";
        #endregion

        #region 获取群列表
        private const string GetGroupNameListMask2Url = "http://s.web2.qq.com/api/get_group_name_list_mask2";
        private const string GetGroupNameListMask2Referer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetGroupNameListMask2Host = "s.web2.qq.com";
        private const string GetGroupNameListMask2Origin = "http://s.web2.qq.com";
        #endregion

        #region 获取讨论组列表
        private const string GetDiscusListUrl = "http://s.web2.qq.com/api/get_discus_list?clientid={0}&psessionid={1}&vfwebqq={2}&t={3}";
        private const string GetDiscusListReferer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetDiscusListHost = "s.web2.qq.com";
        #endregion

        #region 获取个人信息
        private const string GetSelfInfo2Url = "http://s.web2.qq.com/api/get_self_info2?t={0}";
        private const string GetSelfInfo2Referer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetSelfInfo2Host = "s.web2.qq.com";
        #endregion

        #region 获取在线列表
        private const string GetOnlineBuddies2Url = "http://d1.web2.qq.com/channel/get_online_buddies2?vfwebqq={0}&clientid={1}&psessionid={2}&t={3}";
        private const string GetOnlineBuddies2Referer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string GetOnlineBuddies2Host = "d1.web2.qq.com";
        #endregion

        #region 最近联系列表
        private const string RecentList2Url = "http://d1.web2.qq.com/channel/get_recent_list2";
        private const string RecentList2Referer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string RecentList2Host = "d1.web2.qq.com";
        private const string RecentList2Origin = "http://d1.web2.qq.com";
        #endregion

        #region 心跳/消息等
        private const string Poll2Url = "http://d1.web2.qq.com/channel/poll2";
        private const string Poll2Referer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string Poll2Host = "d1.web2.qq.com";
        private const string Poll2Origin = "http://d1.web2.qq.com";
        #endregion

        #region 获取群成员列表
        private const string GetGroupInfoExt2Url = "http://s.web2.qq.com/api/get_group_info_ext2?gcode={0}&vfwebqq={1}&t={2}";
        private const string GetGroupInfoExt2Referer = "http://s.web2.qq.com/proxy.html?v=20130916001&callback=1&id=1";
        private const string GetGroupInfoExt2Host = "s.web2.qq.com";
        #endregion

        #region 获取讨论组成员列表
        private const string GetDiscuInfoUrl = "http://d1.web2.qq.com/channel/get_discu_info?did={0}&vfwebqq={1}&clientid={2}&psessionid={3}&t={4}";
        private const string GetDiscuInfoReferer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string GetDiscuInfoHost = "d1.web2.qq.com";
        #endregion

        #region 发送消息
        private const string SendBuddyMsg2Url = "http://d1.web2.qq.com/channel/send_buddy_msg2";
        private const string SendBuddyMsg2Referer = "http://d1.web2.qq.com/proxy.html?v=20151105001&callback=1&id=2";
        private const string SendBuddyMsg2Host = "d1.web2.qq.com";
        private const string SendBuddyMsg2Origin = "http://d1.web2.qq.com"; 
        #endregion

    }
}
