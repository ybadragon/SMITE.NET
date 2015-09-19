using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI.Implementations
{
    class APIDataUsed
    {
        [JsonProperty("Active_Sessions")]
        public int ActiveSessions { get; set; }
        [JsonProperty("Concurrent_Sessions")]
        public int ConcurrentSessions { get; set; }
        [JsonProperty("Request_Limit_Daily")]
        public int DailyRequestLimit { get; set; }
        [JsonProperty("Session_Cap")]
        public int SessionCap { get; set; }
        [JsonProperty("Session_Time_Limit")]
        public int SessionTimeLimit { get; set; }
        [JsonProperty("Total_Requests_Today")]
        public int TotalDailyRequests { get; set; }
        [JsonProperty("Total_Sessions_Today")]
        public int TotalDailySessions { get; set; }
        [JsonProperty("ret_msg")]
        public string ReturnMessage { get; set; }
    }
}
