using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APIESportsProLeagueDetail
    {
        [JsonProperty("away_team_clan_id")]
        public long AwayTeamID { get; set; }
        [JsonProperty("away_team_name")]
        public string AwayTeamName { get; set; }
        [JsonProperty("away_team_tagname")]
        public string AwayTeamTagName { get; set; }
        [JsonProperty("home_team_clan_id")]
        public long HomeTeamID { get; set; }
        [JsonProperty("home_team_name")]
        public string HomeTeamName { get; set; }
        [JsonProperty("home_team_tagname")]
        public string HomeTeamTagName { get; set; }
        [JsonProperty("map_instance_id")]
        public string MapInstanceID { get; set; }
        [JsonProperty("match_date")]
        public DateTime MatchDateTime { get; set; }
        [JsonProperty("match_number")]
        public int MatchNumber { get; set; }
        [JsonProperty("matchup_id")]
        public long MatchUpID { get; set; }
        [JsonProperty("region")]
        public string RegionCode { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("tournament_name")]
        public string TournamentName { get; set; }
        [JsonProperty("winning_team_clan_id")]
        public int WinningTeamID { get; set; }
    }
}
