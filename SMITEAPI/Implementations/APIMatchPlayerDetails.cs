using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    class APIMatchPlayerDetails
    {
        [JsonProperty("Account_Level")]
        public long PlayerAccountLevel { get; set; }
        [JsonProperty("GodId")]
        public long PlayerGodID { get; set; }
        [JsonProperty("GodName")]
        public string PlayerGodName { get; set; }
        [JsonProperty("Mastery_Level")]
        public long PlayerMasteryLevel { get; set; }
        [JsonProperty("Match")]
        public long PlayerMatchID { get; set; }
        [JsonProperty("Queue")]
        public string PlayerQueueID { get; set; }
        [JsonProperty("SkinId")]
        public long PlayerSkinID { get; set; }
        [JsonProperty("Tier")]
        public long PlayerTier { get; set; }
        [JsonProperty("playerCreated")]
        public string PlayerCreated { get; set; }
        [JsonProperty("playerId")]
        public long PlayerID { get; set; }
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("taskForce")]
        public long PlayerTaskForce { get; set; }
        [JsonProperty("tierLosses")]
        public long PlayerTierLosses { get; set; }
        [JsonProperty("tierWins")]
        public long PlayerTierWins { get; set; }
    }
}