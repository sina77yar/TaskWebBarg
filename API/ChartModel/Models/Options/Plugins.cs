﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public class Plugins : Base
    {
        /// <summary>
        /// The chart legend displays data about the datasets that are appearing on the chart.
        /// </summary>
        public Legend Legend { get; set; }

        /// <summary>
        /// The chart title defines text to draw at the top of the chart.
        /// </summary>
        public Title Title { get; set; }

        /// <summary>
        /// Subtitle is a second title placed under the main title, by default.
        /// </summary>
        public Title Subtitle { get; set; }

        /// <summary>
        /// The global options for the chart tooltips.
        /// </summary>
        public ToolTip Tooltip { get; set; }

        /// <summary>
        /// Allow to modify color options used for displaying the datasets.
        /// The plugin is included in Chart.js by default.
        /// </summary>
        public ColorPlugin Colors { get; set; }
    }
}
