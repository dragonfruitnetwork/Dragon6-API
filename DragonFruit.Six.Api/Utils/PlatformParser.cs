﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Utils
{
    public static class PlatformParser
    {
        /// <summary>
        /// Convert Platform ID -> API Enum
        /// </summary>
        public static Platform GetPlatform(string platformId) => (Platform)Enum.Parse(typeof(Platform), platformId, true);

        /// <summary>
        /// Ubisoft string to <see cref="Platform"/> (reverses <see cref="PlatformIdentifierFor"/>)
        /// </summary>
        public static Platform PlatformEnumFor(string platformName) => platformName.ToUpperInvariant() switch
        {
            "UPLAY" => Platform.PC,
            "PSN" => Platform.PSN,
            "XBL" => Platform.XB1,

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// <see cref="Platform"/> Identifier to Ubisoft string (inverse of <see cref="PlatformEnumFor"/>)
        /// </summary>
        public static string PlatformIdentifierFor(Platform platform) => platform switch
        {
            Platform.PSN => "psn",
            Platform.XB1 => "xbl",
            Platform.PC => "uplay",

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Enumerates over all <see cref="Platform"/>s, producing a <see cref="Dictionary{TKey,TValue}"/>
        /// of platforms to a user-defined value
        /// </summary>
        internal static Dictionary<T, Platform> PlatformsTo<T>(Func<Platform, T> selector)
        {
            var platforms = (Platform[])Enum.GetValues(typeof(Platform));
            return platforms.ToDictionary(selector.Invoke, x => x);
        }
    }
}
