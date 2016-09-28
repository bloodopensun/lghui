using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.RecentList2
{
    public class Result
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }
    }
}
