﻿using Newtonsoft.Json;
using System;

namespace API.Helpers
{
    /// <summary>
    /// If input string value is a bool or int then output without quotes
    /// </summary>
    public class BoolIntStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (bool.TryParse(value.ToString(), out bool boolValue))
            {
                writer.WriteValue(boolValue);
            }
            else if (int.TryParse(value.ToString(), out int intValue))
            {
                if (value.ToString().StartsWith("+") || value.ToString().StartsWith("-"))
                {
                    writer.WriteValue(value.ToString());
                }
                else
                {
                    writer.WriteValue(intValue);
                }
            }
            else
            {
                writer.WriteValue(value.ToString());
            }
        }
    }
}
