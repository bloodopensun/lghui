using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.UserFriends2
{
    public class Marknames
    {
        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("markname")]
        public string Markname { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; } 
    }
}