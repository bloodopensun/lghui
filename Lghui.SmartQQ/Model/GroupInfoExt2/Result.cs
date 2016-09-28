using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupInfoExt2
{
    public class Result
    {
        [JsonProperty("stats")]
        public List<Stats> Stats { get; set; }

        [JsonProperty("minfo")]
        public List<Minfo> Minfo { get; set; }

        [JsonProperty("ginfo")]
        public Ginfo Ginfo { get; set; }

        [JsonProperty("cards")]
        public List<Cards> Cards { get; set; }

        [JsonProperty("vipinfo")]
        public List<Vipinfo> Vipinfo { get; set; }
    }
}