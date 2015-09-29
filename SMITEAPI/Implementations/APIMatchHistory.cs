using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APIMatchHistory
    {
        [JsonProperty("ActiveId1")]
        public long ActiveID1 { get; set; }
        [JsonProperty("ActiveId2")]
        public long ActiveID2 { get; set; }
        [JsonProperty("Active_1")]
        public string Active1 { get; set; }
        [JsonProperty("Active_2")]
        public string Active2 { get; set; }
        [JsonProperty("Active_3")]
        public string Active3 { get; set; }
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
        [JsonProperty("Creeps")]
        public long Creeps { get; set; }
        [JsonProperty("Damage")]
        public long Damage { get; set; }
        [JsonProperty("Damage_Bot")]
        public long BotDamage { get; set; }
        [JsonProperty("Damage_Mitigated")]
        public long DamageMitigated { get; set; }
        [JsonProperty("Damage_Structure")]
        public long DamageStructure { get; set; }
        [JsonProperty("Damage_Taken")]
        public long DamageTaken { get; set; }
        [JsonProperty("Deaths")]
        public long Deaths { get; set; }
        [JsonProperty("God")]
        public string GodName { get; set; }
        [JsonProperty("GodId")]
        public long GodID { get; set; }
        [JsonProperty("Gold")]
        public long Gold { get; set; }
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
        [JsonProperty("Item_1")]
        public string Item1Name { get; set; }
        [JsonProperty("Item_2")]
        public string Item2Name { get; set; }
        [JsonProperty("Item_3")]
        public string Item3Name { get; set; }
        [JsonProperty("Item_4")]
        public string Item4Name { get; set; }
        [JsonProperty("Item_5")]
        public string Item5Name { get; set; }
        [JsonProperty("Item_6")]
        public string Item6Name { get; set; }
        [JsonProperty("Killing_Spree")]
        public long KillingSpree { get; set; }
        [JsonProperty("Kills")]
        public long Kills { get; set; }
        [JsonProperty("Level")]
        public long Level { get; set; }
        [JsonProperty("Match")]
        public long MatchID { get; set; }
        [JsonProperty("Match_Time")]
        public DateTime MatchTime { get; set; }
        [JsonProperty("Minutes")]
        public long MatchMinutes { get; set; }
        [JsonProperty("Multi_kill_Max")]
        public long MaxMultiKill { get; set; }
        [JsonProperty("Queue")]
        public string MatchQueueName { get; set; }
        [JsonProperty("Skin")]
        public string Skin { get; set; }
        [JsonProperty("SkinId")]
        public long SkinID { get; set; }
        [JsonProperty("Surrendered")]
        public string Surrendered { get; set; }
        [JsonProperty("Team1Score")]
        public long Team1Score { get; set; }
        [JsonProperty("Team2Score")]
        public long Team2Score { get; set; }
        [JsonProperty("Win_Status")]
        public string WinStatus { get; set; }
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
