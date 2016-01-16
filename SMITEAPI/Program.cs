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

            int DEVID = 0;
            APICall.Initialize(DEVID, "AUTHKEY", @"DEBUG_LOG_LOCATION", "http://api.smitegame.com/smiteapi.svc/");
            APISession session = null;
            APIGodInfo[] gods = APICall.Call<APIGodInfo[]>(APICall.CallType.GetGods, APICall.ReturnMethod.JSON, ref session, ((int)APICall.LanguageCode.English).ToString());
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to close.");
            Console.ForegroundColor = c;
            Console.ReadKey();
        }
    }
}
