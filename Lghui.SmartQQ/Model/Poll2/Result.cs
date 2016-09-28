using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.Poll2
{
    public class Result
    {
        [JsonProperty("poll_type")]
        public string PollType { get; set; }

        [JsonProperty("value")]
        public Value Value { get; set; }
    }
}
