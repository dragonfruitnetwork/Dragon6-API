﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Utils;

// ReSharper disable once InconsistentNaming

namespace DragonFruit.Six.Api.Requests
{
    /// <summary>
    /// Base for requesting general stats from the main endpoint
    /// </summary>
    public class BasicStatsRequest : PlatformSpecificRequest
    {
        protected IEnumerable<string> _stats;

        public override string Path => Platform.StatsEndpoint();

        /// <summary>
        /// Initialises a <see cref="BasicStatsRequest"/> for a single <see cref="AccountInfo"/>
        /// </summary>
        public BasicStatsRequest(AccountInfo account)
            : base(account.Yield())
        {
        }

        /// <summary>
        /// Initialises a <see cref="BasicStatsRequest"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public BasicStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of stats to fetch (can be found in <see cref="Strings"/> namespace
        /// </summary>
        [QueryParameter("statistics", CollectionConversionMode.Concatenated)]
        public virtual IEnumerable<string> Stats
        {
            get => _stats ?? this.GetDefaultStats();
            set => _stats = value;
        }

        [QueryParameter("populations", CollectionConversionMode.Concatenated)]
        internal override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
