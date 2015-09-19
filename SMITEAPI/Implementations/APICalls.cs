using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

            [Description("{0}{1}/{2}/{3}/{4}/{5}/{6})\n{callName}{ResponseFormat}/{developerId}/{signature}/{session}/{timestamp}/{player}/{queue}")]
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

        public static string APICall(Call call, ReturnMethod type)
        {
            string dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string mySig = GetMD5Hash(String.Format(SignatureFormat, DEVID, call.ToString().ToLower(), AUTHKEY, dt));
            string mycall = String.Format(API_URI, call.ToString().ToLower(), type.ToString().ToLower(), DEVID,
                mySig, dt);
            return mycall;

        }

        public static string APICall(Call call, ReturnMethod type, string s)
        {
            string dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string mySig = GetMD5Hash(String.Format(SignatureFormat, DEVID, call.ToString().ToLower(), AUTHKEY, dt));
            string mycall = prefix + call.ToString().ToLower() + type.ToString().ToLower() + "/" + DEVID + "/" + mySig +
                            "/" + s + "/" + dt;
            return mycall;
        }

        public static string GetPlayer(Call call, ReturnMethod type, APISession session, params string[] playerName)
        {
            string dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string mySig = GetMD5Hash(String.Format(SignatureFormat, DEVID, call.ToString().ToLower(), AUTHKEY, dt));
            string mycall = prefix + call.ToString().ToLower() + type.ToString().ToLower() + "/" + DEVID + "/" + mySig +
                            "/" + session.session_id + "/" + dt + "/" + playerName;
            return mycall;
        }

        public static string APICall(Call call, ReturnMethod type, APISession session, params string[] args)
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
                    session.session_id,
                    dt
                };
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

        //public static string APICall(Call call, ReturnMethod type, Session session)

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
