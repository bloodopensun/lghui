using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model
{
    public class SmartQQModel<T>
    {
        [JsonProperty("retcode")]
        public int Retcode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
