﻿namespace API.Plugins.Zoom
{
    /// <summary>
    /// Requires Zoom and Pan plugin.
    /// https://github.com/chartjs/chartjs-plugin-zoom
    /// </summary>
    public class ZoomOptions : Models.Options
    {
        public Pan Pan { get; set; }

        public Zoom Zoom { get; set; }
    }
}
