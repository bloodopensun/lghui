using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.SelfInfo2
{
    public class Birthday
    {
        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }
    }
}
