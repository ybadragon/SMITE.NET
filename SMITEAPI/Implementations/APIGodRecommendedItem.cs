using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    class APIGodRecommendedItem
    {

        [JsonProperty("Category")]
        public string ItemCategory { get; set; }
        [JsonProperty("Item")]
        public string ItemName { get; set; }
        [JsonProperty("Role")]
        public string ItemRole { get; set; }
        [JsonProperty("category_value_id")]
        public long ItemCategoryID { get; set; }
        [JsonProperty("god_id")]
        public long GodID { get; set; }
        [JsonProperty("god_name")]
        public string GodName { get; set; }
        [JsonProperty("icon_id")]
        public long ItemIconID { get; set; }
        [JsonProperty("item_id")]
        public long ItemID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
        [JsonProperty("role_value_id")]
        public long ItemRoleID { get; set; }
    }
}
