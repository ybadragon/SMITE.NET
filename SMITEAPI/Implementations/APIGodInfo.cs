using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIGodInfo
    {

        [JsonProperty("Ability1")]
        public string Ability1 { get; set; }
        [JsonProperty("Ability2")]
        public string Ability2 { get; set; }
        [JsonProperty("Ability3")]
        public string Ability3 { get; set; }
        [JsonProperty("Ability4")]
        public string Ability4 { get; set; }
        [JsonProperty("Ability5")]
        public string Ability5 { get; set; }
        [JsonProperty("AbilityId1")]
        public long Ability1ID { get; set; }
        [JsonProperty("AbilityId2")]
        public long Ability2ID { get; set; }
        [JsonProperty("AbilityId3")]
        public long Ability3ID { get; set; }
        [JsonProperty("AbilityId4")]
        public long Ability4ID { get; set; }
        [JsonProperty("AbilityId5")]
        public long Ability5ID { get; set; }
        [JsonProperty("Ability_1")]
        public APIAbilityInfo Ability1Info { get; set; }
        [JsonProperty("Ability_2")]
        public APIAbilityInfo Ability2Info { get; set; }
        [JsonProperty("Ability_3")]
        public APIAbilityInfo Ability3Info { get; set; }
        [JsonProperty("Ability_4")]
        public APIAbilityInfo Ability4Info { get; set; }
        [JsonProperty("Ability_5")]
        public APIAbilityInfo Ability5Info { get; set; }
        [JsonProperty("AttackSpeed")]
        public decimal BaseAttackSpeed { get; set; }
        [JsonProperty("AttackSpeedPerLevel")]
        public decimal AttackSpeedScaling { get; set; }
        [JsonProperty("Cons")]
        public string Cons { get; set; }
        [JsonProperty("HP5PerLevel")]
        public decimal HP5Scaling { get; set; }
        [JsonProperty("Health")]
        public decimal BaseHP { get; set; }
        [JsonProperty("HealthPerFive")]
        public decimal BaseHP5 { get; set; }
        [JsonProperty("HealthPerLevel")]
        public decimal HPScaling { get; set; }
        [JsonProperty("Lore")]
        public string Lore { get; set; }
        [JsonProperty("MP5PerLevel")]
        public decimal MP5Scaling { get; set; }
        [JsonProperty("MagicProtection")]
        public decimal BaseMagicProtection { get; set; }
        [JsonProperty("MagicProtectionPerLevel")]
        public decimal MagicProtectionScaling { get; set; }
        [JsonProperty("MagicalPower")]
        public decimal BaseMagicalPower { get; set; }
        [JsonProperty("MagicalPowerPerLevel")]
        public decimal MagicalPowerScaling { get; set; }
        [JsonProperty("Mana")]
        public decimal BaseMP { get; set; }
        [JsonProperty("ManaPerFive")]
        public decimal BaseMP5 { get; set; }
        [JsonProperty("ManaPerLevel")]
        public decimal MPScaling { get; set; }
        [JsonProperty("Name")]
        public string GodName { get; set; }
        [JsonProperty("OnFreeRotation")]
        public string OnFreeRotationFlag { get; set; }
        [JsonProperty("Pantheon")]
        public string PantheonName { get; set; }
        [JsonProperty("PhysicalPower")]
        public decimal BasePhysicalPower { get; set; }
        [JsonProperty("PhysicalProtection")]
        public decimal BasePhysicalProtection { get; set; }
        [JsonProperty("PhysicalProtectionPerLevel")]
        public decimal PhysicalProtectionScaling { get; set; }
        [JsonProperty("Pros")]
        public string Pros { get; set; }
        [JsonProperty("Roles")]
        public string Roles { get; set; }
        [JsonProperty("Speed")]
        public decimal BaseSpeed { get; set; }
        [JsonProperty("Title")]
        public string GodTitle { get; set; }
        [JsonProperty("Type")]
        public string GotType { get; set; }
        [JsonProperty("abilityDescription1")]
        public APIAbilityDescriptionInfo AbilityDescription1Info { get; set; }
        [JsonProperty("godAbility1_URL")]
        public Uri Ability1IconUri { get; set; }
        [JsonProperty("godAbility2_URL")]
        public Uri Ability2IconUri { get; set; }
        [JsonProperty("godAbility3_URL")]
        public Uri Ability3IconUri { get; set; }
        [JsonProperty("godAbility4_URL")]
        public Uri Ability4IconUri { get; set; }
        [JsonProperty("godAbility5_URL")]
        public Uri Ability5IconUri { get; set; }
        [JsonProperty("godCard_URL")]
        public Uri GodCardUri { get; set; }
        [JsonProperty("godIcon_URL")]
        public Uri GodIconUri { get; set; }
        [JsonProperty("id")]
        public long GodID { get; set; }
        [JsonProperty("latestGod")]
        public string LatestGodFlag { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }

    }

    public class APIAbilityInfo
    {

        [JsonProperty("Description")]
        public APIAbilityDescriptionInfo AbilityDescriptionInfo { get; set; }
        [JsonProperty("Id")]
        public long AbilityID { get; set; }
        [JsonProperty("Summary")]
        public string AbilitySummary { get; set; }
        [JsonProperty("URL")]
        public Uri AbilityIconUri { get; set; }

    }

    public class APIAbilityDescriptionInfo
    {

        [JsonProperty("itemDescription")]
        public APIAbilityDescription AbilityDescription { get; set; }

    }

    public class APIAbilityDescription
    {

        [JsonProperty("cooldown")]
        public string AbilityCooldown { get; set; }
        [JsonProperty("cost")]
        public string AbilityCostByLevel { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("menuitems")]
        public APIMenuItems[] AbilityMenuItems { get; set; }
        [JsonProperty("rankitems")]
        public APIRankItems[] AbilityRankItems { get; set; }
        [JsonProperty("secondaryDescription")]
        public string SecondaryDescription { get; set; }

    }

    public class APIMenuItems
    {

        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }

    }

    public class APIRankItems
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
