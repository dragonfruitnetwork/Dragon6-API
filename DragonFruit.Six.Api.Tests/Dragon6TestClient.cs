﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Tokens;
using DragonFruit.Six.Api.Services.Developer;

namespace DragonFruit.Six.Api.Tests
{
    /// <summary>
    /// Dragon6 Client For API Testing. Should NOT be used outside of this repo.
    /// </summary>
    public class Dragon6TestClient : Dragon6DeveloperClient
    {
        // This is a limited access key. If you want one for your own app contact DragonFruit. If we detect this key has been abused it will be reset
        public Dragon6TestClient()
            : base("obN8C3Hgi16twnv9S8LJ1Sdkieh7Hyx7qnXmoHkn6Y")
        {
        }

        protected override TokenBase GetToken()
        {
            var token = base.GetToken();

            // the developer key we have has a limited scope so the expiry is masked - abusing this system will result in an IP ban.
            // you MUST NOT use the API developer key for any personal projects. If you want one please open an issue or contact dragonfruit
            token.Expiry = DateTimeOffset.Now.AddMinutes(5);

            return token;
        }
    }
}
