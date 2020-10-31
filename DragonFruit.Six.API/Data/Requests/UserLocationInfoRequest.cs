﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.API.Data.Requests
{
    public class UserLocationInfoRequest : ApiRequest
    {
        public override string Path => "https://public-ubiservices.ubi.com/v2/profiles/me/iplocation";
    }
}
