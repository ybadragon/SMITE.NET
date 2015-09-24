using SMITEAPI.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SMITEAPI_DAL;
using APISession = SMITEAPI.Implementations.APISession;

namespace SMITEAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            APICall.SerializationPath = @"G:\JSONDebugging";
            APISession session = null;
            //APIPlayer player = APICalls.APICall<APIPlayer[]>(APICalls.Call.GetPlayer, APICalls.ReturnMethod.JSON, ref session, "ybadragon").First();
            var objreturn = APICall.Call<APIESportsProLeagueDetail>(APICall.CallType.GetEsportsProLeagueDetails, APICall.ReturnMethod.JSON, ref session);
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to close.");
            Console.ForegroundColor = c;
            Console.ReadKey();
        }
    }
}
