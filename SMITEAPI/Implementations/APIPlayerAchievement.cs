using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    public class APIPlayerAchievement
    {
        [JsonProperty("DoubleKills")]
        public int DoubleKills { get; set; }
        [JsonProperty("FirstBloods")]
        public string FirstBloods { get; set; }
        [JsonProperty("Id")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string PlayerName { get; set; }
        [JsonProperty("PentaKills")]
        public int PentaKills { get; set; }
        [JsonProperty("QuadraKills")]
        public int QuadraKills { get; set; }
        [JsonProperty("TowerKills")]
        public int TowerKills { get; set; }
        [JsonProperty("TripleKills")]
        public int TripleKills { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }

    }
}
