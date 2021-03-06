﻿// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Utils;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class SeasonalRanksTests
    {
        [TestCase(5, 1)]
        [TestCase(4000, 21)]
        [TestCase(3012, 18)]
        [TestCase(6050, 23)]
        public void TestMMR(int mmr, byte expectedRankId)
        {
            var rank = SeasonalRanks.GetFromMMR(mmr);
            Assert.AreEqual(expectedRankId, rank.Id);
        }

        [TestCase(-25, 1)]
        [TestCase(3300, 17)]
        [TestCase(4150, 19)]
        [TestCase(4800, 20)]
        public void TestLegacyMMR(int mmr, byte expectedRankId)
        {
            var rank = SeasonalRanks.GetFromMMR(mmr, true);
            Assert.AreEqual(expectedRankId, rank.Id);
        }
    }
}
