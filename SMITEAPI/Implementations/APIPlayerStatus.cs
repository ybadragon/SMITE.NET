using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIPlayerStatus
    {
        [JsonProperty("Match")]
        public long MatchID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("status")]
        public APICall.PlayerStatus PlayerStatus { get; set; }
    }
}
