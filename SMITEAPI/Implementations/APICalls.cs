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
        private static string _SerializationPath;
        private const string SERIALIZATION_DEBUG = @"{0}\{1}.json";
        //private const int DEVID = 1004;
        //private const string AUTHKEY = "23DF3C7E9BD14D84BF892AD206B6755C";
        private const string prefix = "http://api.smitegame.com/smiteapi.svc/";
        private const string SignatureFormat = "{0}{1}{2}{3}";
        public static SMITEAPIModel Context = new SMITEAPIModel();

        public enum Call
        {
            [Description("{0}{1}\n{callName}{ResponseFormat}")]
            Ping,

            [Description("{0}{1}/{2}/{3}/{4}\n{callName}{ResponseFormat}/{developerId}/{signature}/{timestamp}")]
            CreateSession,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}")]
            TestSession,

            [Description("{0}{1}/{2}/{3}/{4}/{5}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}")]
            GetDataUsed,

            //[Obsolete("Use APICalls.Call.GetMatchDetails", true)]
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{match_id}")]
            GetDemoDetails,

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

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{match_id}")]
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

        public enum PlayerStatus
        {
            Offline,
            InLobby,
            GodSelection,
            InGame,
            Online,
            Unknown
        }

        public enum Queue
        {
            Conquest5v5 = 423,
            NoviceQueue = 424,
            Conquest = 426,
            Practice = 427,
            ConquestChallenge = 429,
            ConquestRanked = 430,
            Domination = 433,
            [Description("Use with MOTD_CLOSE (465) to get all MOTD matches.")]
            MOTD = 434,
            Arena = 435,
            ArenaChallenge = 438,
            DominationChallenge = 439,
            JoustLeague = 440,
            JoustChallenge = 441,
            Assault = 445,
            AssaultChallenge = 446,
            Joust3v3 = 448,
            ConquestLeague = 451,
            ArenaLeague = 452,
            MOTD_CLOSE = 465
        }

        public enum LanguageCode
        {
            English = 1,
            German,
            French,
            Spanish,
            Spanish_LatinAmerica,
            Portuguese,
            Russian,
            Polish,
            Turkish
        }

        public enum Tier
        {
            BronzeV = 1,
            BronzeIV,
            BronzeIII,
            BronzeII,
            BronzeI,
            SilverV,
            SilverIV,
            SilverIII,
            SilverII,
            SilverI,
            GoldV,
            GoldIV,
            GoldIII,
            GoldII,
            GoldI,
            PlatinumV,
            PlatinumIV,
            PlatinumIII,
            PlatinumII,
            PlatinumI,
            DiamondV,
            DiamondIV,
            DiamondIII,
            DiamondII,
            DiamondI,
            MastersI
        }

        public static string SerializationPath
        {
            get { return _SerializationPath; }
            set
            {
                if (value.EndsWith(@"\"))
                {
                    value = value.Remove(value.LastIndexOf(@"\"));
                }
                _SerializationPath = value;
            }
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
            if (typeof(T) != typeof(APISession) && call != Call.Ping)
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
            T objReturn = JsonConvert.DeserializeObject<T>(result);
#if DEBUG
            using (FileStream fs = File.Open(String.Format(SERIALIZATION_DEBUG, SerializationPath, call), FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, objReturn);
                //serializer.Serialize(jw, queueStats);
            }
#endif
            return objReturn;
        }

        private static string FormatURL(Call call, ReturnMethod type, string[] args, APISession session = null)
        {
            string uri = "";
            List<string> arguments = new List<string>()
            {
                    call.ToString().ToLower(),
                    type.ToString().ToLower(),
            };
            if (call != Call.Ping)
            {
                string dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                string mySig = GetMD5Hash(String.Format(SignatureFormat, DEVID, call.ToString().ToLower(), AUTHKEY, dt));
                arguments.AddRange(new List<string>
                {
                    DEVID.ToString(),
                    mySig,
                });
                if (session != null)
                {
                    arguments.Add(session.session_id);
                }
                arguments.Add(dt);
                if (args.Any())
                {
                    arguments.AddRange(args.ToList());
                }
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
