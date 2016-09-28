using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Members
    {
        [JsonProperty("muin")]
        public long Muin { get; set; }

        [JsonProperty("mflag")]
        public int Mflag { get; set; }
    }
}