﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class OperatorStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<OperatorStats> GetOperatorStats<T>(this T client, AccountInfo account, IEnumerable<OperatorStats> operators) where T : Dragon6Client
            => GetOperatorStats(client, new[] { account }, operators).First();

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static IEnumerable<IEnumerable<OperatorStats>> GetOperatorStats<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new OperatorStatsRequest(group, operators);
                var data = client.Perform<JObject>(request);

                foreach (var id in request.AccountIds)
                {
                    yield return data.DeserializeOperatorStatsFor(id, operators);
                }
            }
        }
    }
}
