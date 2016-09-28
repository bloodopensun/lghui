using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.OnlineBuddies2
{
    public class Result
    {
        [JsonProperty("client_type")]
        public int ClientType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }
    }
}
