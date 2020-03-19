﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Verification
{
    public class VerifiedUserInfo
    {
        [JsonProperty("Level")]
        public Level AccountLevel { get; set; }

        [JsonProperty("Guid")]
        public string GUID { get; set; }

        [JsonProperty("YTLink")]
        public string YouTube { get; set; }

        [JsonProperty("TwitchLink")]
        public string Twitch { get; set; }

        [JsonProperty("ImageHeaderLink")]
        public string Image { get; set; }

        [JsonProperty("CustomText")]
        public string CustomLevelText { get; set; }

        [JsonProperty("CustomIcon")]
        public string CustomLevelIcon { get; set; }

        [JsonProperty("CustomColour")]
        public string CustomLevelColour { get; set; }
    }
}
