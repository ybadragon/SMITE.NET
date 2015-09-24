using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APITeamInfo
    {
        [JsonProperty("Founder")]
        public string Founder { get; set; }
        [JsonProperty("Name")]
        public string TeamName { get; set; }
        [JsonProperty("Players")]
        public int PlayerCount { get; set; }
        [JsonProperty("Tag")]
        public string TeamTag { get; set; }
        [JsonProperty("TeamId")]
        public int TeamID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
