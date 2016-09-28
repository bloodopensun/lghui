using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscuInfo
{
    public class MemInfo
    {

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }
    }
}