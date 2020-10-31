﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data.Requests
{
    public class ServerStatusRequest : ApiRequest
    {
        public override string Path => "https://game-status-api.ubisoft.com/v1/instances";

        /// <summary>
        /// Initialises a <see cref="ServerStatusRequest" /> for all siege platforms
        /// </summary>
        public ServerStatusRequest()
            : this(UbisoftIdentifiers.GameIds.Keys)
        {
        }

        /// <inheritdoc />
        public ServerStatusRequest(params string[] appIds)
            : this((IEnumerable<string>)appIds)
        {
        }

        /// <summary>
        /// Initialises a <see cref="ServerStatusRequest"/> for the app ids provided
        /// </summary>
        public ServerStatusRequest(IEnumerable<string> appIds)
        {
            AppIds = appIds;
        }

        public IEnumerable<string> AppIds { get; set; }

        [QueryParameter("appIds")]
        protected string CompiledAppIds => string.Join(",", AppIds);
    }
}
