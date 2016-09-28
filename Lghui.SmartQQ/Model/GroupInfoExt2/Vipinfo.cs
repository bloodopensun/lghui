using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Vipinfo
    {
        [JsonProperty("vip_level")]
        public int VipLevel { get; set; }

        [JsonProperty("u")]
        public long U { get; set; }

        [JsonProperty("is_vip")]
        public int IsVip { get; set; }
    }
}
