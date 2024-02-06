using API.Helpers;
using Newtonsoft.Json;

namespace API.Models
{
    public class Hover : Base
    {
        public string Mode { get; set; }

        public bool? Intersect { get; set; }

        public int? AnimationDuration { get; set; }

        [JsonConverter(typeof(PlainJsonStringConverter))]
        public string OnHover { get; set; }
    }
}
