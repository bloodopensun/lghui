using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Ginfo
    {
        [JsonProperty("face")]
        public int Face { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("class")]
        public int Class { get; set; }

        [JsonProperty("fingermemo")]
        public string Fingermemo { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("createtime")]
        public long Createtime { get; set; }

        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gid")]
        public long Gid { get; set; }

        [JsonProperty("owner")]
        public long Owner { get; set; }

        [JsonProperty("members")]
        public List<Members> Members { get; set; }

        [JsonProperty("option")]
        public int Option { get; set; }
    }
}