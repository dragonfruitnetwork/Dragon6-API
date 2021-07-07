﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Strings.Stats
{
    [DefaultStats(typeof(StatsRequest))]
    public static class Ranked
    {
        public static string Kills => "rankedpvp_kills";
        public static string Deaths => "rankedpvp_death";

        public static string Wins => "rankedpvp_matchwon";
        public static string Losses => "rankedpvp_matchlost";

        public static string MatchesPlayed => "rankedpvp_matchplayed";
        public static string Time => "rankedpvp_timeplayed";
    }
}
