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
            APISession session = null;
            APIPlayer[] player = APICalls.APICall<APIPlayer[]>(APICalls.Call.GetPlayer, APICalls.ReturnMethod.JSON, ref session, "ybadragon");
            //var queueStats = APICalls.APICall<object>(APICalls.Call.GetQueueStats, APICalls.ReturnMethod.JSON,ref session, "ybadragon", "451");
            using (FileStream fs = File.Open(@"G:\JSONDebugging\debug.json", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, player);
                //serializer.Serialize(jw, queueStats);
            }

            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to close.");
            Console.ForegroundColor = c;
            Console.ReadKey();
        }
    }
}
