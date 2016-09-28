using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.UserFriends2
{
    public class Friends
    {
        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("categories")]
        public int Categories { get; set; } 
    }
}