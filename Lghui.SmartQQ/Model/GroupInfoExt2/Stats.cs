using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Stats
    {
        [JsonProperty("client_type")]
        public int ClientType { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("stat")]
        public int Stat { get; set; }
    }
}