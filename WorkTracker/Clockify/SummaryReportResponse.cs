using Newtonsoft.Json;

namespace WorkTracker.Clockify
{
     /// <summary>
     /// Summary report response
     /// </summary>
    public class SummaryReportResponse
    {
        /// <summary>
        /// List of totals
        /// </summary>
        [JsonProperty("totals")]
        public List<Total>? Totals { get; set; }
    }
}