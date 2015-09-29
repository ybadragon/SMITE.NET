using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APIQueueStat
    {
        [JsonProperty("Assists")]
        public long PlayerGodQueueAssists { get; set; }
        [JsonProperty("Deaths")]
        public long PlayerGodQueueDeaths { get; set; }
        [JsonProperty("God")]
        public string PlayerGodQueueGod { get; set; }
        [JsonProperty("Kills")]
        public long PlayerGodQueueKills { get; set; }
        [JsonProperty("LastPlayed")]
        public DateTime PlayerGodQueueLastPlayed { get; set; }
        [JsonProperty("Losses")]
        public long PlayerGodQueueLosses { get; set; }
        [JsonProperty("Matches")]
        public long PlayerGodQueueMatches { get; set; }
        [JsonProperty("Minutes")]
        public long PlayerGodQueueMinutes { get; set; }
        [JsonProperty("Queue")]
        public string PlayerGodQueueQueueName { get; set; }
        [JsonProperty("Wins")]
        public long PlayerGodQueueWins { get; set; }
        [JsonProperty("player_id")]
        public string PlayerGodQueuePlayerID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
