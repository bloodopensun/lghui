using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscuInfo
{
    public class Result
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("mem_info")]
        public List<MemInfo> MemInfo { get; set; }

        [JsonProperty("mem_status")]
        public List<MemStatus> MemStatus { get; set; }
    }
}