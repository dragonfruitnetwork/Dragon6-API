﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Services.Developer.Auth
{
    public class DeveloperTokenRequest : DeveloperApiRequest
    {
        public override string Path => $"{BaseEndpoint}/api/v2/dev/token";
    }
}
