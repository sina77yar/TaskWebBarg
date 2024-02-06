﻿using API.Helpers;
using Newtonsoft.Json;

namespace API.Models
{
    // https://www.chartjs.org/docs/3.5.1/configuration/layout.html
    public class Layout : Base
    {
        [JsonConverter(typeof(PaddingConverter))]
        public Padding Padding { get; set; }
    }
}
