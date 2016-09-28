using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscusList
{
    public class Dname
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("did")]
        public long Did { get; set; }
    }
}