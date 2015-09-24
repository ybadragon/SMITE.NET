using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIPlayerFriendInfo
    {
        [JsonProperty("account_id")]
        public string FriendAccountID { get; set; }
        [JsonProperty("avatar_url")]
        public string FriendAvatarURL { get; set; }
        [JsonProperty("name")]
        public string FriendName { get; set; }
        [JsonProperty("player_id")]
        public string FriendPlayerID { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
