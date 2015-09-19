using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APISession
    {
        [JsonProperty("ret_msg")]
        public string ret_msg { get; set; }
        [JsonProperty("session_id")]
        public string session_id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }
    }
}
