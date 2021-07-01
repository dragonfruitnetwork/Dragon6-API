﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Strings.Stats
{
    [DefaultStats(typeof(StatsRequest))]
    public static class Training
    {
        public static string Kills => "generalpve_kills";
        public static string Deaths => "generalpve_death";

        public static string Wins => "generalpve_matchwon";
        public static string Losses => "generalpve_matchlost";

        public static string Time => "generalpve_timeplayed";
        public static string MatchesPlayed => "generalpve_matchplayed";
    }
}
