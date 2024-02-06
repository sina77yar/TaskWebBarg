namespace API.Models
{
    public class TimeTick : CartesianTick
    {
        /// <summary>
        /// How ticks are generated.
        /// </summary>
        public string Source { get; set; }
    }
}
