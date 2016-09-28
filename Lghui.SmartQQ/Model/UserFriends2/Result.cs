using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.UserFriends2
{
    public class Result
    {
        [JsonProperty("friends")]
        public List<Friends> Friends { get; set; }

        [JsonProperty("marknames")]
        public List<Marknames> Marknames { get; set; }

        [JsonProperty("categories")]
        public List<Categories> Categories { get; set; }

        [JsonProperty("vipinfo")]
        public List<Vipinfo> Vipinfo { get; set; }

        [JsonProperty("info")]
        public List<Info> Info { get; set; }
    }
}