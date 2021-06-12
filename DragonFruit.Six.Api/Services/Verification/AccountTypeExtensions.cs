﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Services.Verification
{
    public static class AccountTypeExtensions
    {
        public static string GetName(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomTitle) ? GetDefaultName(dragon6User.AccountRole) : dragon6User.CustomTitle;
        public static string GetIcon(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomIcon) ? GetDefaultIcon(dragon6User.AccountRole) : dragon6User.CustomIcon;
        public static string GetColor(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomColour) ? GetDefaultColor(dragon6User.AccountRole) : dragon6User.CustomColour;

        /// <summary>
        /// Retrieves the default title for the <see cref="AccountRole"/> provided
        /// </summary>
        private static string GetDefaultName(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "Account blocked by admin",
            AccountRole.BlockedBySelf => "Account blocked by owner",

            AccountRole.Verified => "Verified User",
            AccountRole.Beta => "Beta Tester",
            AccountRole.Translator => "Dragon6 Translator",
            AccountRole.Supporter => "Dragon6 Supporter",
            AccountRole.Contributor => "Recognised Contributor",
            AccountRole.Developer => "Dragon6 Admin",

            _ => "Standard User"
        };

        /// <summary>
        /// Retrieves the default icon for the <see cref="AccountRole"/> provided
        /// </summary>
        private static string GetDefaultIcon(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "highlight_off",
            AccountRole.BlockedBySelf => "explore_off",

            AccountRole.Verified => "check",
            AccountRole.Beta => "bug_report",
            AccountRole.Translator => "translate",
            AccountRole.Supporter => "favorite",
            AccountRole.Contributor => "code",
            AccountRole.Developer => "verified_user",

            _ => "face",
        };

        /// <summary>
        /// Retrieves the default title colour for the <see cref="AccountRole"/> provided
        /// </summary>
        private static string GetDefaultColor(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "#BD1818",
            AccountRole.BlockedBySelf => "#BD1818",

            AccountRole.Verified => "#20B2AA",
            AccountRole.Beta => "#FFA500",
            AccountRole.Translator => "#1f8b4c",
            AccountRole.Supporter => "#FFB6C1",
            AccountRole.Contributor => "#3498DB",
            AccountRole.Developer => "#90EE90",

            _ => "#FFFFFF",
        };
    }
}
