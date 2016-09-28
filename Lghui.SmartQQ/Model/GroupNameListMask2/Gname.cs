using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupNameListMask2
{
    public class Gname
    {
        [JsonProperty("flag")]
        public long Flag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gid")]
        public long Gid { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }
}