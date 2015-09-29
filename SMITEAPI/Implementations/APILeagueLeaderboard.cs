using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APILeagueLeaderboard
    {
        [JsonProperty("Leaves")]
        public long PlayerLeaves { get; set; }
        [JsonProperty("Losses")]
        public long PlayerLosses { get; set; }
        [JsonProperty("Name")]
        public string PlayerName { get; set; }
        [JsonProperty("Points")]
        public long PlayerPoints { get; set; }
        [JsonProperty("PrevRank")]
        public long PlayerPreviousRank { get; set; }
        [JsonProperty("Rank")]
        public long PlayerRank { get; set; }
        [JsonProperty("Rank_Stat_Conquest")]
        public string ConquestPlayerRank { get; set; }
        [JsonProperty("Rank_Stat_Joust")]
        public string JoustPlayerRank { get; set; }
        [JsonProperty("Season")]
        public long Season { get; set; }
        [JsonProperty("Tier")]
        public long Tier { get; set; }
        [JsonProperty("Trend")]
        public long Trend { get; set; }
        [JsonProperty("Wins")]
        public long PlayerWins { get; set; }
        [JsonProperty("player_id")]
        public string PlayerID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
