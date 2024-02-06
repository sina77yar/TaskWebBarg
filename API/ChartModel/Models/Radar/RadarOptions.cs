﻿namespace API.Models
{
    public class RadarOptions : Options
    {
        /// <summary>
        /// The number of degrees to rotate the chart clockwise.
        /// </summary>
        public int? StartAngle { get; set; }

        public RadialScale Scale { get; set; }
    }
}
