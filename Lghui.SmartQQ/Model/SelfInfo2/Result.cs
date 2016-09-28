using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.SelfInfo2
{
    public class Result
    {
        [JsonProperty("birthday")]
        public Birthday Birthday { get; set; }

        [JsonProperty("face")]
        public int Face { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("allow")]
        public int Allow { get; set; }

        [JsonProperty("college")]
        public string College { get; set; }

        [JsonProperty("uin")]
        public long Uin { get; set; }

        [JsonProperty("blood")]
        public int Blood { get; set; }

        [JsonProperty("constel")]
        public int Constel { get; set; }

        [JsonProperty("lnick")]
        public string Lnick { get; set; }

        [JsonProperty("vfwebqq")]
        public string Vfwebqq { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("vip_info")]
        public int VipInfo { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("personal")]
        public string Personal { get; set; }

        [JsonProperty("shengxiao")]
        public int Shengxiao { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("account")]
        public long Account { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }
    }
}
