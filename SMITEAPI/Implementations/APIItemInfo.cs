using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMITEAPI.Implementations
{
    public class APIItemInfo
    {

        [JsonProperty("ChildItemId")]
        public long ChildItemID { get; set; }
        [JsonProperty("DeviceName")]
        public string ItemName { get; set; }
        [JsonProperty("IconId")]
        public long ItemIconID { get; set; }
        [JsonProperty("ItemDescription")]
        public APIItemDescriptionInfo ItemDescriptionInfo { get; set; }
        [JsonProperty("ItemId")]
        public long ItemID { get; set; }
        [JsonProperty("ItemTier")]
        public int ItemTier { get; set; }
        [JsonProperty("Price")]
        public int ItemPrice { get; set; }
        [JsonProperty("RootItemId")]
        public long RootItemID { get; set; }
        [JsonProperty("ShortDesc")]
        public string ItemShortDescription { get; set; }
        [JsonProperty("StartingItem")]
        public bool IsStartingItem { get; set; }
        [JsonProperty("Type")]
        public string ItemType { get; set; }
        [JsonProperty("itemIcon_URL")]
        public Uri ItemIconURI { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }

    }

    public class APIItemDescriptionInfo
    {

        [JsonProperty("Description")]
        public string ItemDescription { get; set; }
        [JsonProperty("Menuitems")]
        public APIMenuItems[] ItemMenuItems { get; set; }
        [JsonProperty("SecondaryDescription")]
        public string SecondaryDescription { get; set; }

    }
}
