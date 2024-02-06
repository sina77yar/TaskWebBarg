using API.Helpers;
using Newtonsoft.Json;

namespace API.Models
{
    public class LineScatterData : Base
    {
        [JsonConverter(typeof(DoubleStringConverter))]
        public string X { get; set; }

        [JsonConverter(typeof(DoubleStringConverter))]
        public string Y { get; set; }
    }
}
