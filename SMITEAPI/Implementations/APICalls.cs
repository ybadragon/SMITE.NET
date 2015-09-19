using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SMITEAPI_DAL;

namespace SMITEAPI.Implementations
{
    class APICalls
    {
        private const int DEVID = 1277;
        private const string AUTHKEY = "3548F1CF47504F1DAA55F3C5F9759EA7";
        //private const int DEVID = 1004;
        //private const string AUTHKEY = "23DF3C7E9BD14D84BF892AD206B6755C";
        private static string API_URI = "http://api.smitegame.com/smiteapi.svc/{0}{1}/{2}/{3}/{4}";
        private static string prefix = "http://api.smitegame.com/smiteapi.svc/";
        private static string SignatureFormat = "{0}{1}{2}{3}";
        private static SMITEAPIModel Context = new SMITEAPIModel();

        public enum Call
        {
            [Description("{0}{1}/{2}/{3}/{4}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            CreateSession,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetDataUsed,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetPlayer,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetPlayerStatus,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetGods,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetItems,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetGodRecommendedItems,

            [Description("{0}{1}/{2}/{3}{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetMatchDetails,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetMatchPlayerDetails,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{playerName}")]
            GetMatchIdsByQueue,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{queue}/{tier}/{season}")]
            GetLeagueLeaderboard,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{queue}")]
            GetLeagueSeasons,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{player}")]
            GetMatchHistory,

            [Description("{0}{1}/{2}/{3}/{4}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}")]
            GetMotD,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7})\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{player}/{queue}")]
            GetQueueStats,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/signature}/{session}/{timestamp}/{clanid}")]
            GetTeamDetails,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/signature}/{session}/{timestamp}/{clanid}")]
            GetTeamPlayers,

            [Description("{0}{1}/{2}/{3}/{4}\n{callName}{ResponseFormat}/{developerId}/signature}/{session}/{timestamp}")]
            GetTopMatches,

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/signature}/{session}/{timestamp}/{searchteam}")]
            SearchTeams

        }

        public enum ReturnMethod
        {
            JSON,
            XML
        }

        private static APISession GetLiveSession(ref APISession tempSession)
        {
            TimeSpan span = new TimeSpan(0, 15, 0);
            SMITEAPI_DAL.APISession session = Context.Sessions.OrderByDescending(x => x.timestamp).FirstOrDefault();
            if (session != null)
            {
                if (session.timestamp.Add(span) > DateTime.UtcNow)
                {
                    tempSession = new APISession {session_id = session.session_id, timestamp = session.timestamp, ret_msg = session.ret_msg};
                    return tempSession;
                }
                else
                {
                    Context.Sessions.Remove(session);
                }
            }
            return APICall<APISession>(Call.CreateSession, ReturnMethod.JSON, ref tempSession);
        }

        public static T APICall<T>(Call call, ReturnMethod type, ref APISession session, params string[] args)
        {
            if (typeof(T) != typeof(APISession))
            {
                session = GetLiveSession(ref session);
                string id = session.session_id;
                if (!Context.Sessions.Any(x => x.session_id == id))
                {
                    Context.Sessions.Add(new SMITEAPI_DAL.APISession()
                    {
                        ret_msg = session.ret_msg,
                        session_id = session.session_id,
                        timestamp = session.timestamp
                    });
                }
                Context.SaveChanges();
            }

            WebRequest request = WebRequest.Create(FormatURL(call, type, args, session));
            WebResponse resp = request.GetResponse();
            string result;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            JsonSerializer serializer = new JsonSerializer();
            return JsonConvert.DeserializeObject<T>(result);
        }

        private static string FormatURL(Call call, ReturnMethod type, string[] args, APISession session = null)
        {
            string dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string mySig = GetMD5Hash(String.Format(SignatureFormat, DEVID, call.ToString().ToLower(), AUTHKEY, dt));
            string uri = "";
            List<string> arguments = new List<string>
                {
                    call.ToString().ToLower(),
                    type.ToString().ToLower(),
                    DEVID.ToString(),
                    mySig,
                };
            if (session != null)
            {
                arguments.Add(session.session_id);
            }
            arguments.Add(dt);
            if (args.Any())
            {
                arguments.AddRange(args.ToList());
            }
            string s = GetCallDescription(call);
            s = prefix + s;
            uri = String.Format(s, arguments.ToArray());
            return uri;
        }

        private static string GetCallDescription(Call call)
        {
            var type = typeof(Call);
            var memInfo = type.GetMember(call.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            description = description.Substring(0, description.IndexOf("\n"));
            return description.Trim();
        }

        private static string GetMD5Hash(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
