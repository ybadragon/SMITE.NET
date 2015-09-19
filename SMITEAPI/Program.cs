using SMITEAPI.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SMITEAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebRequest request = WebRequest.Create("http://api.smitegame.com/smiteapi.svc/pingjson");
            //WebResponse resp = request.GetResponse();
            //using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        Console.WriteLine(sr.ReadLine());
            //    }
            //}

            //create session
            WebRequest request = WebRequest.Create(APICalls.APICall(APICalls.Call.CreateSession, APICalls.ReturnMethod.JSON));
            WebResponse resp = request.GetResponse();
            APISession session = new APISession();
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                string s = sr.ReadToEnd();
                JsonSerializer serializer = new JsonSerializer();
                session = JsonConvert.DeserializeObject<APISession>(s);
                Console.WriteLine();
            }

            request = WebRequest.Create(APICalls.APICall(APICalls.Call.GetDataUsed, APICalls.ReturnMethod.JSON, session));
            resp = request.GetResponse();
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                string s = sr.ReadToEnd();
                JsonSerializer serializer = new JsonSerializer();
                var o = JsonConvert.DeserializeObject(s);
                Console.WriteLine();
            }
            //test comment 2
            //test comment again
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to close.");
            Console.ForegroundColor = c;
            Console.ReadKey();
        }
    }
}
