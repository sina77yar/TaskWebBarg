﻿using API.Models;

namespace API.Plugins.Zoom
{
    /// <summary>
    /// Requires Zoom and Pan plugin.
    /// https://github.com/chartjs/chartjs-plugin-zoom
    /// </summary>
    public class ZoomLineOptions : LineOptions
    {
        public Pan Pan { get; set; }

        public Zoom Zoom { get; set; }
    }
}
