using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscuInfo
{
    public class Info
    {
        [JsonProperty("did")]
        public long Did { get; set; }

        [JsonProperty("discu_name")]
        public string DiscuName { get; set; }

        [JsonProperty("mem_list")]
        public List<Mem> MemList { get; set; }
    }
}