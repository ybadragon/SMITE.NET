using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APITeamDetail
    {
        [JsonProperty("Founder")]
        public string TeamFounder { get; set; }
        [JsonProperty("FounderId")]
        public string TeamFounderID { get; set; }
        [JsonProperty("Losses")]
        public int TeamLosses { get; set; }
        [JsonProperty("Name")]
        public string TeamName { get; set; }
        [JsonProperty("Players")]
        public int TeamPlayerCount { get; set; }
        [JsonProperty("Rating")]
        public int TeamRating { get; set; }
        [JsonProperty("Tag")]
        public string TeamTag { get; set; }
        [JsonProperty("TeamId")]
        public long TeamID { get; set; }
        [JsonProperty("Wins")]
        public int TeamWins { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
