using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Minfo
    {
        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
