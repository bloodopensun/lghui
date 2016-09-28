using Lghui.SmartQQ.Enum.Poll2;
using Lghui.SmartQQ.Enum.SendBuddyMsg2;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.Poll2
{
    public class Result
    {
        [JsonProperty("poll_type")]
        public PollType PollType { get; set; }

        [JsonProperty("value")]
        public Value Value { get; set; }
    }
}
