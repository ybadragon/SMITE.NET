using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    public class APIPlayer
    {
        [JsonProperty("Avatar_URL")]
        public string AvatarURL { get; set; }
        [JsonProperty("Created_Datetime")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("Id")]
        public int? ID { get; set; }
        [JsonProperty("Last_Login_Datetime")]
        public DateTime? LastLoginDate { get; set; }
        [JsonProperty("LeagueConquest")]
        public QueueInfo LeagueConquest { get; set; }
        [JsonProperty("LeagueJoust")]
        public QueueInfo LeagueJoust { get; set; }
        [JsonProperty("Leaves")]
        public int? Leaves { get; set; }
        [JsonProperty("Level")]
        public int? Level { get; set; }
        [JsonProperty("MasteryLevel")]
        public int? MasteryLevel { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Rank_Stat")]
        public int? RankStat { get; set; }
        [JsonProperty("Rank_Stat_Joust")]
        public int? RankStatJoust { get; set; }
        [JsonProperty("TeamId")]
        public int? TeamID { get; set; }
        [JsonProperty("Team_Name")]
        public string TeamName { get; set; }
        [JsonProperty("Tier_Conquest")]
        public int? TierConquest { get; set; }
        [JsonProperty("Tier_Joust")]
        public int? TierJoust { get; set; }
        [JsonProperty("Total_Achievements")]
        public int? TotalAchievements { get; set; }
        [JsonProperty("Total_Worshippers")]
        public int? TotalWorshippers { get; set; }
        [JsonProperty("Wins")]
        public int? Wins { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }

    public class QueueInfo
    {
        [JsonProperty("Leaves")]
        public int? Leaves { get; set; }
        [JsonProperty("Losses")]
        public int? Losses { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Points")]
        public int? Points { get; set; }
        [JsonProperty("PrevRank")]
        public int? PrevRank { get; set; }
        [JsonProperty("Rank")]
        public int? Rank { get; set; }
        [JsonProperty("Rank_Stat_Conquest")]
        public int? RankStatConquest { get; set; }
        [JsonProperty("Rank_Stat_Joust")]
        public int? RankStatJoust { get; set; }
        [JsonProperty("Season")]
        public int? Season { get; set; }
        [JsonProperty("Tier")]
        public int? Tier { get; set; }
        [JsonProperty("Wins")]
        public int? Wins { get; set; }
        [JsonProperty("player_id")]
        public int? PlayerID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
