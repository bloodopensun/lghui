using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.Login2
{
    public class Result
    {
        [JsonProperty("cip")]
        public int Cip { get; set; }

        [JsonProperty("f")]
        public int F { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("psessionid")]
        public string Psessionid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("user_state")]
        public int UserState { get; set; }

        [JsonProperty("vfwebqq")]
        public string Vfwebqq { get; set; }
    }
}