using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APITopMatch
    {
        [JsonProperty("Ban1")]
        public string Ban1 { get; set; }
        [JsonProperty("Ban1Id")]
        public int Ban1ID { get; set; }
        [JsonProperty("Ban2")]
        public string Ban2 { get; set; }
        [JsonProperty("Ban2Id")]
        public int Ban2ID { get; set; }
        [JsonProperty("Entry_Datetime")]
        public DateTime MatchDateTime { get; set; }
        [JsonProperty("LiveSpectators")]
        public long Spectators { get; set; }
        [JsonProperty("Match")]
        public long MatchID { get; set; }
        [JsonProperty("Match_Time")]
        public int TimeOfMatch { get; set; }
        [JsonProperty("OfflineSpectators")]
        public long OfflineSpectators { get; set; }
        [JsonProperty("Queue")]
        public string Queue { get; set; }
        [JsonProperty("RecordingFinished")]
        public DateTime RecordingFinishedTime { get; set; }
        [JsonProperty("RecordingStarted")]
        public DateTime RecordingStartedTime { get; set; }
        [JsonProperty("Team1_AvgLevel")]
        public int Team1AverageLevel { get; set; }
        [JsonProperty("Team1_Gold")]
        public long Team1Gold { get; set; }
        [JsonProperty("Team1_Kills")]
        public int Team1Kills { get; set; }
        [JsonProperty("Team1_Score")]
        public int Team1Score { get; set; }
        [JsonProperty("Team2_AvgLevel")]
        public int Team2AverageLevel { get; set; }
        [JsonProperty("Team2_Gold")]
        public long Team2Gold { get; set; }
        [JsonProperty("Team2_Kills")]
        public int Team2Kills { get; set; }
        [JsonProperty("Team2_Score")]
        public int Team2Score { get; set; }
        [JsonProperty("WinningTeam")]
        public int WinningTeam { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
