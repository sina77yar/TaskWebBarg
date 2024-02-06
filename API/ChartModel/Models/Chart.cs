﻿using System;
using API.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace API.Models
{
    public class Chart : Base
    {
        public Enums.ChartType Type { get; set; }

        public Data Data { get; set; }

        public Options Options { get; set; }

        [JsonConverter(typeof(PlainJsonStringConverter))]
        public string Plugins { get; set; }

        public string SerializeBody()
        {
            // keys need to be camel case to match data contract so use custom serializer to alter
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelcaseContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));

            string json = JsonConvert.SerializeObject(this, settings);

            return json;
        }

        /// <summary>
        /// Generates client side code for this <see cref="Chart"/> suitable for inclusion in a script tag.
        /// </summary>
        /// <param name="canvasId">ID of HTML canvas tag to hold the chart.</param>
        /// <returns>JavaScript code snippet.</returns>
        public string CreateChartCode(string canvasId)
        {
            string code = $"var {canvasId}Element = document.getElementById(\"{canvasId}\");{Environment.NewLine}";
            code += $"var {canvasId} = new Chart({canvasId}Element, ";

            // keys need to be camel case to match data contract so use custom serializer to alter
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelcaseContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));

            string json = JsonConvert.SerializeObject(this, settings);

            code += $"{json}\r\n";
            code += ");";

            return code;
        }

        public Chart()
        {
            Options = new Options();
        }
    }
}
