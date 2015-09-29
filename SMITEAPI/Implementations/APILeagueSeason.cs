using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APILeagueSeason
    {
        [JsonProperty("complete")]
        public bool SeasonComplete { get; set; }
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("name")]
        public string Season { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
