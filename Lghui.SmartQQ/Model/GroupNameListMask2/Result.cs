using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lghui.SmartQQ.Model.GroupNameListMask2
{
    public class Result
    {
        [JsonProperty("gmasklist")]
        public List<Gmask> GmaskList { get; set; }

        [JsonProperty("gnamelist")]
        public List<Gname> GnameList { get; set; }

        [JsonProperty("gmarklist")]
        public List<Gmark> GmarkList { get; set; }
    }
}
