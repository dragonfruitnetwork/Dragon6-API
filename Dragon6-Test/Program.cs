﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dragon6.API.Test
{
    class Program
    {
        async static Task Main(string[] args)
        {
            string token = await new HttpClient().GetAsync("https://dragon6.dragonfruit.network/api/token").Result.Content.ReadAsStringAsync(); //YOU MUST GET PERMISSION BEFORE USING OUR TOKEN SERVER
            var PlayerInfo = await AccountInfo.ReverseID_PC("14c01250-ef26-4a32-92ba-e04aa557d619", token);

            var GeneralStats = await PlayerStats.GetStats(PlayerInfo, token);
            var SeasonStats = await SeasonalStats.GetSeason(PlayerInfo, -1, "EMEA", token);
            var OPStats = await OperatorStats.GetOperatorStats(PlayerInfo, token);
            var Level = await PlayerStats.GetLevel(PlayerInfo, token);

            var Account = new JObject()
            {
                {"PlayerInfo",JToken.FromObject(PlayerInfo)},
                {"Level",Level},
                {"GeneralStats",JToken.FromObject(GeneralStats)},
                {"Ranked",JToken.FromObject(SeasonStats)},
                {"Operator",JToken.FromObject(OPStats)}
            };

            Console.WriteLine(JsonConvert.SerializeObject(Account, Formatting.Indented));

            Environment.Exit(0);
        }
    }
}
