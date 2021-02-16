﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests;

namespace DragonFruit.Six.Api.Utils
{
    public static class OperatorData
    {
        /// <summary>
        /// Loads the operator info datasheet from a local file
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static IEnumerable<OperatorStats> FromFile(string location)
        {
            return FileServices.ReadFile<IEnumerable<OperatorStats>>(location);
        }

        /// <summary>
        /// Gets the <see cref="IEnumerable{T}"/> needed to use the <see cref="OperatorStatsRequest"/>
        /// </summary>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        public static IEnumerable<OperatorStats> GetOperatorInfo(this ApiClient client)
        {
            var request = new OperatorDataRequest(null);
            return client.Perform<IEnumerable<OperatorStats>>(request);
        }
    }
}
