using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APITeamPlayerInfo
    {

        [JsonProperty("AccountLevel")]
        public int PlayerAccountLevel { get; set; }
        [JsonProperty("JoinedDatetime")]
        public DateTime PlayerJoinedDateTime { get; set; }
        [JsonProperty("LastLoginDateTime")]
        public DateTime PlayerLastLoginDate { get; set; }
        [JsonProperty("Name")]
        public string PlayerName { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        }
}
