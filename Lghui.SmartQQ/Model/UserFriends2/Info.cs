using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.UserFriends2
{
    public class Info
    {
        [JsonProperty("face")]
        public int Face { get; set; }

        [JsonProperty("flag")]
        public long Flag { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }
    }
}