using Newtonsoft.Json;

namespace WorkTracker.Clockify
{
    /// <summary>
    /// Total
    /// </summary>
    public class Total
    {
        /// <summary>
        /// Total billable time
        /// </summary>
        [JsonProperty("totalBillableTime")]
        public int TotalBillableTime { get; set; }
    }
}