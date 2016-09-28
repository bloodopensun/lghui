using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Cards
    {
        [JsonProperty("muin")]
        public long Muin { get; set; }

        [JsonProperty("card")]
        public string Card { get; set; }
    }
}