﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Models
{
    public abstract class Base
    {
        /// <summary>
        /// Container for storing custom plugin values.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> PluginDynamic { get; set; }
    }
}
