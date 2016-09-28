using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.Poll2
{
    public class Value
    {
        [JsonProperty("content")]
        public List<dynamic> Content { get; set; }

        [JsonProperty("did")]
        public long Did { get; set; }

        [JsonProperty("from_uin")]
        public long FromUin { get; set; }

        [JsonProperty("group_code")]
        public long GroupCode { get; set; }

        [JsonProperty("msg_id")]
        public long MsgId { get; set; }

        [JsonProperty("msg_type")]
        public long MsgType { get; set; }

        [JsonProperty("send_uin")]
        public long SendUin { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("to_uin")]
        public long ToUin { get; set; }
    }
}
