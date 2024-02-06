using System.Collections.Generic;

namespace API.Models
{
    // TODO: Implement mixed chart types.
    public class Data : Base
    {
        public IList<Dataset> Datasets { get; set; }

        public IList<string> Labels { get; set; }

        public IList<string> XLabels { get; set; }

        public IList<string> YLabels { get; set; }
    }
}
