using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscuInfo
{
    public class Mem
    {

        [JsonProperty("mem_uin")]
        public long MemUin { get; set; }


        [JsonProperty("ruin")]
        public long Ruin { get; set; }
    }
}