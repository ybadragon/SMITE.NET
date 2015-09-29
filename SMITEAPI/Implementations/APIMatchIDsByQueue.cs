using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    class APIMatchIDsByQueue
    {
        [JsonProperty("Active_Flag")]
        public string ActiveFlag { get; set; }
        [JsonProperty("Match")]
        public string MatchID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
