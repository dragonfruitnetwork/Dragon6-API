﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class AccountInfo : IEquatable<AccountInfo>
    {
        /// <summary>
        /// The Player's Username (case-correct)
        /// </summary>
        [JsonProperty("name")]
        public string PlayerName { get; set; }

        /// <summary>
        /// URL to avatar photo (256*256)
        /// </summary>
        [JsonProperty("image")]
        public string Image => $"https://ubisoft-avatars.akamaized.net/{Identifiers.Ubisoft}/default_256_256.png";

        /// <summary>
        /// User Platform
        /// </summary>
        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        /// <summary>
        /// User identifiers (Platform, Profile and Ubisoft)
        /// </summary>
        [JsonProperty("identifiers")]
        public UserIdentifierContainer Identifiers { get; set; }

        public bool Equals(AccountInfo other) => Identifiers.Profile.Equals(other?.Identifiers.Profile);

        public override string ToString() => $"{Identifiers.Ubisoft}|{Platform}";
    }
}
