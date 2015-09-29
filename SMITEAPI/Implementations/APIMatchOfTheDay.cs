using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APIMatchOfTheDay
    {
        [JsonProperty("description")]
        public string MatchDescription { get; set; }
        [JsonProperty("gameMod")]
        public string GameMode { get; set; }
        [JsonProperty("maxPlayers")]
        public string MaxPlayers { get; set; }
        [JsonProperty("name")]
        public string MatchName { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("startDateTime")]
        public DateTime MatchStartTime { get; set; }
        [JsonProperty("team1GodsCSV")]
        public string Team1GodsCSV { get; set; }
        [JsonProperty("team2GodsCSV")]
        public string Team2GodsCSV { get; set; }
        [JsonProperty("title")]
        public string MatchTitle { get; set; }
    }
}
