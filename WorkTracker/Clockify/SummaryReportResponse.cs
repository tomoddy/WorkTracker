using Newtonsoft.Json;

namespace WorkTracker.Clockify
{

    public class SummaryReportResponse
    {

        [JsonProperty("totals")]
        public List<Total>? Totals { get; set; }
    }
}