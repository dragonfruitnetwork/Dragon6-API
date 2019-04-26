﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    /// <summary>
    /// Takes Ubisoft JSON and pareses it into a Dragon6 Class
    /// </summary>
    /// <param name="json"></param>
    /// <param name="GUID"></param>
    /// <returns></returns>
    class Alignments
    {
        /// <summary>
        /// Aligns into an AccountInfo Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> AlignAccount(string json)
        {
            var values = await Task.Run(() => JObject.Parse(json));

            var Ai = new AccountInfo
            {
                PlayerName = values["profiles"][0]["nameOnPlatform"].ToString(),
                Image =
                    $"https://ubisoft-avatars.akamaized.net/{values["profiles"][0]["profileId"]}/default_146_146.png?appId=39baebad-39e5-4552-8c25-2c9b919064e2",
                GUID = values["profiles"][0]["profileId"].ToString(),
                Platform = (string)values["profiles"][0]["platformType"] == "uplay"? References.Platforms.PC : (string)values["profiles"][0]["platformType"] == "psn" ? References.Platforms.PSN:References.Platforms.XB1
            };
            return Ai;
        }

        /// <summary>
        /// Aligns into an PlayerStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<PlayerStats> AlignGeneralStats(string json,string GUID)
        {
            var PlayerObj = await Task.Run( () => JObject.Parse(json));
            return new PlayerStats
            {
                // Casual
                Casual_Kills = int.Parse((string)PlayerObj["results"][GUID]["casualpvp_kills:infinite"] ?? "0"),
                Casual_Deaths = int.Parse((string)PlayerObj["results"][GUID]["casualpvp_death:infinite"] ?? "0"),
                Casual_KD = float.Parse((string)PlayerObj["results"][GUID]["casualpvp_kills:infinite"] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID]["casualpvp_death:infinite"] ?? "1"),

                Casual_Wins = int.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchwon:infinite"] ?? "0"),
                Casual_Losses = int.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchlost:infinite"] ?? "0"),
                Casual_WL = float.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchwon:infinite"] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchlost:infinite"] ?? "1"),

                Casual_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchplayed:infinite"] ?? "0"),

                // General
                Barricades = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_barricadedeployed:infinite"] ?? "0"),
                Reinforcements = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_reinforcementdeploy:infinite"] ?? "0"),

                Downs = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_dbno:infinite"] ?? "0"),
                Revives = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_revive:infinite"] ?? "0"),

                Headshots = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_headshot:infinite"] ?? "0"),
                Knifes = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_meleekills:infinite"] ?? "0"),

                Assists = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_killassists:infinite"] ?? "0"),
                Suicides = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_suicide:infinite"] ?? "0"),

                // Terrorist Hunt
                THunt_Kills = int.Parse((string)PlayerObj["results"][GUID]["generalpve_kills:infinite"] ?? "0"),
                THunt_Deaths = int.Parse((string)PlayerObj["results"][GUID]["generalpve_death:infinite"] ?? "0"),
                THunt_KD = float.Parse((string)PlayerObj["results"][GUID]["generalpve_kills:infinite"] ?? "1") /
                           float.Parse((string)PlayerObj["results"][GUID]["generalpve_death:infinite"] ?? "1"),

                THunt_Wins = int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchwon:infinite"] ?? "0"),
                THunt_Losses = int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchlost:infinite"] ?? "0"),
                THunt_WL = float.Parse((string)PlayerObj["results"][GUID]["generalpve_matchwon:infinite"] ?? "1") /
                           float.Parse((string)PlayerObj["results"][GUID]["generalpve_matchlost:infinite"] ?? "1"),
                THunt_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchwon:infinite"] ?? "0") + int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchlost:infinite"] ?? "0"),

                // Gamemodes
                HIScore_Secure =
                    int.Parse((string)PlayerObj["results"][GUID]["secureareapvp_bestscore:infinite"] ?? "0"),
                HIScore_Bomb = int.Parse((string)PlayerObj["results"][GUID]["plantbombpvp_bestscore:infinite"] ?? "0"),
                HIScore_Hostage =
                    int.Parse((string)PlayerObj["results"][GUID]["rescuehostagepvp_bestscore:infinite"] ?? "0"),

                // Time Played
                TimePlayed_Casual =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID]["casualpvp_timeplayed:infinite"] ?? "0")),
                TimePlayed_THunt =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID]["generalpve_timeplayed:infinite"] ?? "0")),
                TimePlayed_Ranked =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID]["rankedpvp_timeplayed:infinite"] ?? "0")),
                TimePlayed_General =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID]["generalpvp_timeplayed:infinite"] ?? "0")),
                TimePlayed_Custom =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID]["custompvp_timeplayed:infinite"] ?? "0")),

                // Ranked
                Ranked_Wins = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchwon:infinite"] ?? "0"),
                Ranked_Losses = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchlost:infinite"] ?? "0"),
                Ranked_WL = float.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchwon:infinite"] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchlost:infinite"] ?? "1"),
                Ranked_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchplayed:infinite"] ?? "0"),

                Ranked_Kills = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_kills:infinite"] ?? "0"),
                Ranked_Deaths = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_death:infinite"] ?? "0"),
                Ranked_KD = float.Parse((string)PlayerObj["results"][GUID]["rankedpvp_kills:infinite"] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID]["rankedpvp_death:infinite"] ?? "1"),

                // General
                Wins = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_matchwon:infinite"] ?? "0"),
                Losses = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_matchlost:infinite"] ?? "0"),
                Kills = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_kills:infinite"] ?? "0"),
                Deaths = int.Parse((string)PlayerObj["results"][GUID]["generalpvp_death:infinite"] ?? "0"),
                WL = float.Parse((string)PlayerObj["results"][GUID]["generalpvp_matchwlratio:infinite"] ?? "0"),
                MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID]["rankedpvp_matchplayed:infinite"] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID]["casualpvp_matchplayed:infinite"] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchwon:infinite"] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID]["generalpve_matchlost:infinite"] ?? "0")
            };

        }

        /// <summary>
        /// Aligns into an SeasonalStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<SeasonalStats> AlignSeason(string json,string GUID)
        {
            var response = await Task.Run(() =>
                JObject.Parse(json));

            return new SeasonalStats
            {
                Season = (int)response["players"][GUID]["season"],
                Rank = (int)response["players"][GUID]["rank"],
                Max_Rank = (int)response["players"][GUID]["max_rank"],
                Wins = (int)response["players"][GUID]["wins"],
                Losses = (int)response["players"][GUID]["losses"],
                Abandons = (int)response["players"][GUID]["abandons"],
                MMR = (int)response["players"][GUID]["mmr"]
            };

        }

        /// <summary>
        /// Gets the User's Level as an int32
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<int> AlignLevel(string json)
        {
            return (int)await Task.Run(() =>
                JObject.Parse(json)["player_profiles"]
                    [0]["level"]);
        }
    }
}