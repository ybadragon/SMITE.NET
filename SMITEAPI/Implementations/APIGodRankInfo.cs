using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIGodRankInfo
    {
        [JsonProperty("Rank")]
        public int GodRank { get; set; }
        [JsonProperty("Worshippers")]
        public long TotalWorshippers { get; set; }
        [JsonProperty("god")]
        public string GodName { get; set; }
        [JsonProperty("god_id")]
        public string GodID { get; set; }
        [JsonProperty("player_id")]
        public string PlayerID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
