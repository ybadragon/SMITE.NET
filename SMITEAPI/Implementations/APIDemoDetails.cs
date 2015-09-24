using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIDemoDetails
    {
        [JsonProperty("Ban1")]
        public string Ban1 { get; set; }
        [JsonProperty("Ban2")]
        public string Ban2 { get; set; }
        [JsonProperty("Entry_Datetime")]
        public DateTime MatchDateTime { get; set; }
        [JsonProperty("Match")]
        public long MatchID { get; set; }
        [JsonProperty("Match_Time")]
        public int MatchTime { get; set; }
        [JsonProperty("Offline_Spectators")]
        public long OfflineSpectators { get; set; }
        [JsonProperty("Realtime_Spectators")]
        public long RealtimeSpectators { get; set; }
        [JsonProperty("Recording_Ended")]
        public DateTime RecordingEndDate { get; set; }
        [JsonProperty("Recording_Started")]
        public DateTime RecordingStartDate { get; set; }
        [JsonProperty("Team1_AvgLevel")]
        public int Team1AverageLevel { get; set; }
        [JsonProperty("Team1_Gold")]
        public long Team1TotalGold { get; set; }
        [JsonProperty("Team1_Kills")]
        public long Team1TotalKills { get; set; }
        [JsonProperty("Team1_Score")]
        public long Team1Score { get; set; }
        [JsonProperty("Team2_AvgLevel")]
        public int Team2AverageLevel { get; set; }
        [JsonProperty("Team2_Gold")]
        public long Team2TotalGold { get; set; }
        [JsonProperty("Team2_Kills")]
        public long Team2TotalKills { get; set; }
        [JsonProperty("Team2_Score")]
        public long Team2Score { get; set; }
        [JsonProperty("Winning_Team")]
        private int WinningTeam { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
