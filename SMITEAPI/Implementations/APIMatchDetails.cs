using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    class APIMatchDetails
    {
        [JsonProperty("Account_Level")]
        public long AccountLevel { get; set; }
        [JsonProperty("ActiveId1")]
        public long ActiveID1 { get; set; }
        [JsonProperty("ActiveId2")]
        public long ActiveID2 { get; set; }
        [JsonProperty("Assists")]
        public long Assists { get; set; }
        [JsonProperty("Ban1")]
        public string Ban1 { get; set; }
        [JsonProperty("Ban1Id")]
        public long Ban1ID { get; set; }
        [JsonProperty("Ban2")]
        public string Ban2 { get; set; }
        [JsonProperty("Ban2Id")]
        public long Ban2ID { get; set; }
        [JsonProperty("Ban3")]
        public string Ban3 { get; set; }
        [JsonProperty("Ban3Id")]
        public long Ban3ID { get; set; }
        [JsonProperty("Ban4")]
        public string Ban4 { get; set; }
        [JsonProperty("Ban4Id")]
        public long Ban4ID { get; set; }
        [JsonProperty("Ban5")]
        public string Ban5 { get; set; }
        [JsonProperty("Ban5Id")]
        public long Ban5ID { get; set; }
        [JsonProperty("Ban6")]
        public string Ban6 { get; set; }
        [JsonProperty("Ban6Id")]
        public long Ban6ID { get; set; }
        [JsonProperty("Camps_Cleared")]
        public long CampsCleared { get; set; }
        [JsonProperty("Conquest_Losses")]
        public long ConquestLosses { get; set; }
        [JsonProperty("Conquest_Points")]
        public long ConquestPoints { get; set; }
        [JsonProperty("Conquest_Tier")]
        public long ConquestTier { get; set; }
        [JsonProperty("Conquest_Wins")]
        public long ConquestWins { get; set; }
        [JsonProperty("Damage_Bot")]
        public long BotDamage { get; set; }
        [JsonProperty("Damage_Done_Magical")]
        public long MagicalDamageDone { get; set; }
        [JsonProperty("Damage_Done_Physical")]
        public long PhysicalDamageDone { get; set; }
        [JsonProperty("Damage_Mitigated")]
        public long DamageMitigated { get; set; }
        [JsonProperty("Damage_Player")]
        public long PlayerDamage { get; set; }
        [JsonProperty("Damage_Taken")]
        public long DamageTaken { get; set; }
        [JsonProperty("Deaths")]
        public long Deaths { get; set; }
        [JsonProperty("Entry_Datetime")]
        public DateTime EntryDateTime { get; set; }
        [JsonProperty("Final_Match_Level")]
        public long FinalMatchLevel { get; set; }
        [JsonProperty("GodId")]
        public long GodID { get; set; }
        [JsonProperty("Gold_Earned")]
        public long GoldEarned { get; set; }
        [JsonProperty("Gold_Per_Minute")]
        public long GoldPerMinute { get; set; }
        [JsonProperty("Healing")]
        public long Healing { get; set; }
        [JsonProperty("ItemId1")]
        public long Item1ID { get; set; }
        [JsonProperty("ItemId2")]
        public long Item2ID { get; set; }
        [JsonProperty("ItemId3")]
        public long Item3ID { get; set; }
        [JsonProperty("ItemId4")]
        public long Item4ID { get; set; }
        [JsonProperty("ItemId5")]
        public long Item5ID { get; set; }
        [JsonProperty("ItemId6")]
        public long Item6ID { get; set; }
        [JsonProperty("Item_Active_1")]
        public string Item1Active { get; set; }
        [JsonProperty("Item_Active_2")]
        public string Item2Active { get; set; }
        [JsonProperty("Item_Active_3")]
        public string Item3Active { get; set; }
        [JsonProperty("Item_Purch_1")]
        public string Item1Purchase { get; set; }
        [JsonProperty("Item_Purch_2")]
        public string Item2Purchase { get; set; }
        [JsonProperty("Item_Purch_3")]
        public string Item3Purchase { get; set; }
        [JsonProperty("Item_Purch_4")]
        public string Item4Purchase { get; set; }
        [JsonProperty("Item_Purch_5")]
        public string Item5Purchase { get; set; }
        [JsonProperty("Item_Purch_6")]
        public string Item6Purchase { get; set; }
        [JsonProperty("Joust_Losses")]
        public long JoustLosses { get; set; }
        [JsonProperty("Joust_Points")]
        public long JoustPoints { get; set; }
        [JsonProperty("Joust_Tier")]
        public long JoustTier { get; set; }
        [JsonProperty("Joust_Wins")]
        public long JoustWins { get; set; }
        [JsonProperty("Killing_Spree")]
        public long KillingSpree { get; set; }
        [JsonProperty("Kills_Bot")]
        public long BotKills { get; set; }
        [JsonProperty("Kills_Double")]
        public long DoubleKills { get; set; }
        [JsonProperty("Kills_Fire_Giant")]
        public long FireGiantKills { get; set; }
        [JsonProperty("Kills_First_Blood")]
        public long FirstBloodKills { get; set; }
        [JsonProperty("Kills_Gold_Fury")]
        public long GoldFuryKills { get; set; }
        [JsonProperty("Kills_Penta")]
        public long PentaKills { get; set; }
        [JsonProperty("Kills_Phoenix")]
        public long PhoenixKills { get; set; }
        [JsonProperty("Kills_Player")]
        public long PlayerKills { get; set; }
        [JsonProperty("Kills_Quadra")]
        public long QuadraKills { get; set; }
        [JsonProperty("Kills_Siege_Juggernaut")]
        public long SiegeJuggernautKills { get; set; }
        [JsonProperty("Kills_Single")]
        public long SingleKills { get; set; }
        [JsonProperty("Kills_Triple")]
        public long TripleKills { get; set; }
        [JsonProperty("Kills_Wild_Juggernaut")]
        public long WildJuggernautKills { get; set; }
        [JsonProperty("Mastery_Level")]
        public long MasteryLevel { get; set; }
        [JsonProperty("Match")]
        public long MatchID { get; set; }
        [JsonProperty("Minutes")]
        public long Minutes { get; set; }
        [JsonProperty("Multi_kill_Max")]
        public long MaxMultikill { get; set; }
        [JsonProperty("PartyId")]
        public long PartyID { get; set; }
        [JsonProperty("Rank_Stat")]
        public long RankStat { get; set; }
        [JsonProperty("Rank_Stat_Joust")]
        public long JoustRankStat { get; set; }
        [JsonProperty("Reference_Name")]
        public string ReferenceName { get; set; }
        [JsonProperty("Skin")]
        public string Skin { get; set; }
        [JsonProperty("SkinId")]
        public long SkinID { get; set; }
        [JsonProperty("Structure_Damage")]
        public long StructureDamage { get; set; }
        [JsonProperty("Surrendered")]
        public string Surrendered { get; set; }
        [JsonProperty("Team1Score")]
        public long Team1Score { get; set; }
        [JsonProperty("Team2Score")]
        public long Team2Score { get; set; }
        [JsonProperty("TeamId")]
        public long TeamID { get; set; }
        [JsonProperty("Team_Name")]
        public string TeamName { get; set; }
        [JsonProperty("Towers_Destroyed")]
        public long TowersDestroyed { get; set; }
        [JsonProperty("Wards_Placed")]
        public long Wards_Placed { get; set; }
        [JsonProperty("Win_Status")]
        public string WinStatus { get; set; }
        [JsonProperty("hasReplay")]
        public string HasReplay { get; set; }
        [JsonProperty("name")]
        public string QueueName { get; set; }
        [JsonProperty("playerId")]
        public long PlayerID { get; set; }
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
