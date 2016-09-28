using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.DiscusList
{
    public class Result
    {
        [JsonProperty("dnamelist")]
        public List<Dname> DnameList { get; set; }
    }
}