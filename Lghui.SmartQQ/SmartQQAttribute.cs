using System.Collections.Generic;
using System.Linq;
using Lghui.Framework.Expand;
using Lghui.Framework.OpenHttp;
using Lghui.SmartQQ.Model;

namespace Lghui.SmartQQ
{
    partial class SmartQQClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private static int ClientId => 53999199;

        private static int MsgId { get; set; } = 80780000;

        private string Ptwebqq
        {
            get { return _httpClient.Cookie.ToCookies().FirstOrDefault(c => c.Name == "ptwebqq")?.Value; }
        }

        private Model.Vfwebqq.Result VfwebqqModel { get; set; }

        private Model.Login2.Result Login2Model { get; set; }

        public Model.UserFriends2.Result UserFriends2Model { get; set; }

        public Model.GroupNameListMask2.Result GroupNameListMask2Model { get; set; }

        public Model.DiscusList.Result DiscusListModel { get; set; }

        public Model.SelfInfo2.Result SelfInfo2Model { get; set; }

        public List<Model.OnlineBuddies2.Result> OnlineBuddies2List { get; set; }

        public List<Model.RecentList2.Result> RecentList2List { get; set; }

        public Dictionary<long, Model.GroupInfoExt2.Result> GroupInfoExt2 { get; } = new Dictionary<long, Model.GroupInfoExt2.Result>();

        public Dictionary<long, Model.DiscuInfo.Result> DiscuInfo { get; } = new Dictionary<long, Model.DiscuInfo.Result>();


        public List<ExpressionModel> Expression = ("[{'Key':'0','value':'惊讶'},{'Key':'1','value':'撇嘴'},{'Key':'2','value':'色'},{'Key':'3','value':'发呆'},{'Key':'4','value':'得意'},{'Key':'5','value':'流泪'},{'Key':'6','value':'害羞'},{'Key':'7','value':'闭嘴'},{'Key':'8','value':'睡'},{'Key':'9','value':'大哭'},{'Key':'10','value':'尴尬'},{'Key':'11','value':'发怒'},{'Key':'12','value':'调皮'},{'Key':'13','value':'龇牙'},{'Key':'14','value':'微笑'},{'Key':'21','value':'飞吻'},{'Key':'23','value':'跳跳'},{'Key':'25','value':'发抖'},{'Key':'26','value':'怄火'},{'Key':'27','value':'爱情'},{'Key':'29','value':'足球'},{'Key':'32','value':'西瓜'},{'Key':'33','value':'玫瑰'},{'Key':'34','value':'凋谢'},{'Key':'36','value':'爱心'},{'Key':'37','value':'心碎'},{'Key':'38','value':'蛋糕'},{'Key':'39','value':'礼物'},{'Key':'42','value':'太阳'},{'Key':'45','value':'月亮'},{'Key':'46','value':'强'},{'Key':'47','value':'弱'},{'Key':'50','value':'难过'},{'Key':'51','value':'酷'},{'Key':'53','value':'抓狂'},{'Key':'54','value':'吐'},{'Key':'55','value':'惊恐'},{'Key':'56','value':'冷汗'},{'Key':'57','value':'憨笑'},{'Key':'58','value':'大兵'},{'Key':'59','value':'猪头'},{'Key':'62','value':'拥抱'},{'Key':'63','value':'咖啡'},{'Key':'64','value':'饭'},{'Key':'71','value':'握手'},{'Key':'72','value':'便便'},{'Key':'73','value':'偷笑'},{'Key':'74','value':'可爱'},{'Key':'75','value':'白眼'},{'Key':'76','value':'傲慢'},{'Key':'77','value':'饥饿'},{'Key':'78','value':'困'},{'Key':'79','value':'奋斗'},{'Key':'80','value':'咒骂'},{'Key':'81','value':'疑问'},{'Key':'82','value':'嘘'},{'Key':'83','value':'晕'},{'Key':'84','value':'折磨'},{'Key':'85','value':'衰'},{'Key':'86','value':'骷髅'},{'Key':'87','value':'敲打'},{'Key':'88','value':'再见'},{'Key':'91','value':'闪电'},{'Key':'92','value':'炸弹'},{'Key':'93','value':'刀'},{'Key':'95','value':'胜利'},{'Key':'96','value':'冷汗'},{'Key':'97','value':'擦汗'},{'Key':'98','value':'抠鼻'},{'Key':'99','value':'鼓掌'},{'Key':'100','value':'糗大了'},{'Key':'101','value':'坏笑'},{'Key':'102','value':'左哼哼'},{'Key':'103','value':'右哼哼'},{'Key':'104','value':'哈欠'},{'Key':'105','value':'鄙视'},{'Key':'106','value':'委屈'},{'Key':'107','value':'快哭了'},{'Key':'108','value':'阴险'},{'Key':'109','value':'亲亲'},{'Key':'110','value':'吓'},{'Key':'111','value':'可怜'},{'Key':'112','value':'菜刀'},{'Key':'113','value':'啤酒'},{'Key':'114','value':'篮球'},{'Key':'115','value':'乒乓'},{'Key':'116','value':'示爱'},{'Key':'117','value':'瓢虫'},{'Key':'118','value':'抱拳'},{'Key':'119','value':'勾引'},{'Key':'120','value':'拳头'},{'Key':'121','value':'差劲'},{'Key':'122','value':'爱你'},{'Key':'123','value':'NO'},{'Key':'124','value':'OK'},{'Key':'125','value':'转圈圈'},{'Key':'126','value':'磕头'},{'Key':'127','value':'回头'},{'Key':'128','value':'跳绳'},{'Key':'129','value':'挥手'},{'Key':'130','value':'激动'},{'Key':'131','value':'街舞'},{'Key':'132','value':'献吻'},{'Key':'133','value':'左太极'},{'Key':'134','value':'右太极'},{'Key':'136','value':'双喜'},{'Key':'137','value':'鞭炮'},{'Key':'138','value':'灯笼'},{'Key':'139','value':'发财'},{'Key':'140','value':'K歌'},{'Key':'141','value':'购物'},{'Key':'142','value':'邮件'},{'Key':'143','value':'帅'},{'Key':'144','value':'喝彩'},{'Key':'145','value':'祈祷'},{'Key':'146','value':'爆筋'},{'Key':'147','value':'棒棒糖'},{'Key':'148','value':'喝奶'},{'Key':'149','value':'下面'},{'Key':'150','value':'香蕉'},{'Key':'151','value':'飞机'},{'Key':'152','value':'开车'},{'Key':'153','value':'高铁左车头'},{'Key':'154','value':'车厢'},{'Key':'155','value':'高铁右车头'},{'Key':'156','value':'多云'},{'Key':'157','value':'下雨'},{'Key':'158','value':'钞票'},{'Key':'159','value':'熊猫'},{'Key':'160','value':'灯泡'},{'Key':'161','value':'风车'},{'Key':'162','value':'闹钟'},{'Key':'163','value':'打伞'},{'Key':'164','value':'彩球'},{'Key':'165','value':'钻戒'},{'Key':'166','value':'沙发'},{'Key':'167','value':'纸巾'},{'Key':'168','value':'药'},{'Key':'169','value':'手枪'},{'Key':'170','value':'青蛙'}]").JsonToModel<List<ExpressionModel>>();
    }
}
