using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.UserFriends2
{
    public class Categories
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } 
    }
}