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
    public class APICall
    {
        private static int DEVID;
        private static string AUTHKEY;
        private static string SerializationPath;
        private const string SERIALIZATION_DEBUG = @"{0}\{1}.json";
        //private const int DEVID = 1004;
        //private const string AUTHKEY = "23DF3C7E9BD14D84BF892AD206B6755C";
        private static string prefix;
        private const string SignatureFormat = "{0}{1}{2}{3}";
        public static SMITEAPIModel Context = new SMITEAPIModel();
        public static string pingDescription;

        public static void Initialize(int DeveloperID, string AuthorizationKey, string serializationPath, string APIEndpoint)
        {
            DEVID = DeveloperID;
            AUTHKEY = AuthorizationKey;
            SerializationPath = serializationPath;
            prefix = APIEndpoint;
        }


        public enum CallType
        {
            /// <summary>
            /// Test the connection to HiRez Servers
            /// <para>Return Type : string</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}")]
            Ping,
            /// <summary>
            /// Create a new session
            /// <para>Return Type : APISession</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}")]
            CreateSession,
            /// <summary>
            /// Test the current session
            /// <para>Return Type : string</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}")]
            TestSession,
            /// <summary>
            /// Get data used for calls made today
            /// <para>Return Type : APIDataUsed</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}")]
            GetDataUsed,
            /// <summary>
            /// Get basic match details
            /// <para>Return Type : APIDemoDetail[]</para>
            /// <para>Required Params : Match ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetDemoDetails,
            /// <summary>
            /// Get details about ESports matches
            /// <para>Return Type : APIESportsProLeagueDetail[]</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}")]
            GetESportsProLeagueDetails,
            /// <summary>
            /// Get a list of the players friends
            /// <para>Return Type : APIPlayerFriendInfo[]</para>
            /// <para>Required Params : Player Name or Player ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetFriends,
            /// <summary>
            /// Get the god ranks for the player
            /// <para>Return Type : APIGodRankInfo[]</para>
            /// <para>Required Params : Player Name or Player ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetGodRanks,
            /// <summary>
            /// Get player details
            /// <para>Return Type : APIPlayer[]</para>
            /// <para>Required Params : Player Name</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetPlayer,
            /// <summary>
            /// Get status of the player
            /// <para>Return Type : APIPlayerStatus[]</para>
            /// <para>Required Params : Player Name</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetPlayerStatus,
            /// <summary>
            /// Get details of all gods
            /// <para>Return Type : APIGodInfo[]</para>
            /// <para>Required Params : Language Code</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetGods,
            /// <summary>
            /// Get details of all items
            /// <para>Return Type : APIItemInfo[]</para>
            /// <para>Required Params : Language Code</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetItems,
            /// <summary>
            /// Get all recommended items for the god
            /// <para>Return Type : APIGodRecommendedItem[]</para>
            /// <para>Required Params : God ID <para>Language Code</para></para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}")]
            GetGodRecommendedItems,
            /// <summary>
            /// Returns statistics for a completed match
            /// <para>Return Type : APIMatchDetails[]</para>
            /// <para>Required Params : Match ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{match_id}")]
            GetMatchDetails,
            /// <summary>
            /// Returns player information for a live match
            /// <para>Return Type : APIMatchPlayerDetails[]</para>
            /// <para>Required Params : Match ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetMatchPlayerDetails,
            /// <summary>
            /// Returns all match IDs for a specific queue
            /// <para>Return Type : APIMatchIDsByQueue[]</para>
            /// <para>Required Params : Queue ID <para>Date <para>Hour</para></para></para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}")]
            GetMatchIdsByQueue,
            /// <summary>
            /// Returns the top players for a specific league
            /// <para>Return Type : APILeagueLeaderboard[]</para>
            /// <para>Required Params : Queue ID <para>Tier <para>Season Number</para></para></para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}")]
            GetLeagueLeaderboard,
            /// <summary>
            /// Returns a list of seasons for a match queue including active season
            /// <para>Return Type : APILeagueSeason[]</para>
            /// <para>Required Params : Queue ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetLeagueSeasons,
            /// <summary>
            /// Returns recent matches and other information
            /// <para>Return Type : APIMatchHistory[]</para>
            /// <para>Required Params : Player Name or Player ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetMatchHistory,
            /// <summary>
            /// Returns information on the 20 most recent matches of the day
            /// <para>Return Type : APIMatchOfTheDay[]</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}")]
            GetMOTD,
            /// <summary>
            /// Returns match summary for player queue by god
            /// <para>Return Type : APIQueueStat[]</para>
            /// <para>Required Params : Player Name or Player ID <para>Queue ID</para></para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}/{7}")]
            GetQueueStats,
            /// <summary>
            /// Returns team players and other information
            /// <para>Return Type : APITeamInfo</para>
            /// <para>Required Params : Clan ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetTeamDetails,
            /// <summary>
            /// Returns team information
            /// <para>Return Type : APITeamPlayerInfo</para>
            /// <para>Required Params : Clan ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetTeamPlayers,
            /// <summary>
            /// Lists 50 most watched and recent matches
            /// <para>Return Type : APITopMatch[]</para>
            /// <para>Required Params : </para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}")]
            GetTopMatches,
            /// <summary>
            /// Returns information for teams containing the team name provided
            /// <para>Return Type : APITeamInfo</para>
            /// <para>Required Params : Team Name</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            SearchTeams,
            /// <summary>
            /// Get all achievements for player
            /// <para>Return Type : APIPlayerAchievement</para>
            /// <para>Required Params : Player ID</para>
            /// </summary>
            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6}")]
            GetPlayerAchievements

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
            return Call<APISession>(CallType.CreateSession, ReturnMethod.JSON, ref tempSession);
        }

        /// <summary>
        /// Use this to make calls to the API. If running in DEBUG this will automatically create a .json file with the response from the api call in the directory provided in APICall.SerializationPath.
        /// </summary>
        /// <typeparam name="T">This is the type that the return object is serialized into. The type returned depends on the Call type so look at the description of the Call to see the type required</typeparam>
        /// <param name="call">This is the name of the method being called</param>
        /// <param name="type">This is the response type</param>
        /// <param name="session">Session can be null</param>
        /// <param name="args">These are everything past the {timestamp} if there is one in the call description</param>
        /// <returns>T</returns>
        public static T Call<T>(CallType call, ReturnMethod type, ref APISession session, params string[] args)
        {
            if (typeof(T) != typeof(APISession) && call != CallType.Ping)
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
            var objReturn = JsonConvert.DeserializeObject<T>(result);
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

        private static string FormatURL(CallType call, ReturnMethod type, string[] args, APISession session = null)
        {
            string uri = "";
            List<string> arguments = new List<string>()
            {
                    call.ToString().ToLower(),
                    type.ToString().ToLower(),
            };
            if (call != CallType.Ping)
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

        private static string GetCallDescription(CallType call)
        {
            var type = typeof(CallType);
            var memInfo = type.GetMember(call.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            description = description.Contains("\n") ? description.Substring(0, description.IndexOf("\n")) : description;
            return description.Trim();
        }

        private static Type GetCallReturnType(CallType call)
        {
            var type = typeof (CallType);
            var memInfo = type.GetMember(call.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof (ReturnTypeAttribute), false);
            var returnType = ((ReturnTypeAttribute) attributes[0]).Type;
            return returnType;
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
