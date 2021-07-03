﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Tokens
{
    /// <summary>
    /// An implementation of <see cref="TokenBase"/> representing a direct response from the ubisoft auth servers
    /// </summary>
    public class UbisoftToken : TokenBase
    {
        [JsonProperty("clientIp")]
        public string ClientIP { get; set; }

        [JsonProperty("clientIpCountry")]
        public string ClientCountry { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("expiration")]
        public override DateTimeOffset Expiry { get; set; }

        [JsonProperty("ticket")]
        public override string Token { get; set; }

        [JsonProperty("spaceId")]
        public string SpaceId { get; set; }

        [JsonProperty("sessionId")]
        public override string SessionId { get; set; }

        [JsonProperty("sessionKey")]
        public string SessionKey { get; set; }

        [JsonProperty("account")]
        public AccountInfo Account { get; set; }
    }
}
