﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public class PlayerLevelStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Platform.ProfileStatsEndpoint();

        protected override bool RequireAuth => true;

        public PlayerLevelStatsRequest(AccountInfo account)
            : this(new[] { account })
        {
        }

        public PlayerLevelStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        [QueryParameter("profile_ids")]
        protected override string AccountIdString => base.AccountIdString;
    }
}
