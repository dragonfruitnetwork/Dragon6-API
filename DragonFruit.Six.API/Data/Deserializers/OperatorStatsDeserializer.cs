﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Strings;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class OperatorStatsDeserializer
    {
        public static IEnumerable<OperatorStats> DeserializeOperatorStatsFor(this JObject jObject, string guid, IEnumerable<OperatorStats> data)
        {
            var json = (JObject)jObject[Misc.Results][guid];

            foreach (var op in data)
            {
                op.Guid = guid;

                op.Kills = json.GetUInt(string.Format(OverallOperator.Kills, op.Index));
                op.Deaths = json.GetUInt(string.Format(OverallOperator.Deaths, op.Index));
                op.Kd = json.GetFloat(string.Format(OverallOperator.Kills, op.Index), 1) /
                        json.GetFloat(string.Format(OverallOperator.Deaths, op.Index), 1);

                op.Wins = json.GetUInt(string.Format(OverallOperator.Wins, op.Index));
                op.Losses = json.GetUInt(string.Format(OverallOperator.Losses, op.Index));
                op.Wl = json.GetFloat(string.Format(OverallOperator.Wins, op.Index), 1) /
                        json.GetFloat(string.Format(OverallOperator.Losses, op.Index), 1);

                op.RoundsPlayed = json.GetUInt(string.Format(OverallOperator.Rounds, op.Index));
                op.TimePlayed = TimeSpan.FromSeconds(json.GetUInt(string.Format(OverallOperator.Time, op.Index)));
                op.Headshots = json.GetUInt(string.Format(OverallOperator.Headshots, op.Index));
                op.Downs = json.GetUInt(string.Format(OverallOperator.Downs, op.Index));

                op.ActionCount = json.GetUInt(op.OperatorActionResultId);

                yield return op;
            }
        }
    }
}