using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupNameListMask2
{
    public class Gmark
    {
        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("markname")]
        public string MarkName { get; set; }
    }
}