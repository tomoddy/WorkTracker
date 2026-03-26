using Newtonsoft.Json;

namespace WorkTracker.Clockify
{

    public class SummaryReportRequest(DateTime end, DateTime start)
    {

        [JsonProperty("dateRangeEnd")]
        public DateTime DateRangeEnd { get; set; } = end;


        [JsonProperty("dateRangeStart")]
        public DateTime DateRangeStart { get; set; } = start;


        [JsonProperty("summaryFilter")]
        public SummaryFilter SummaryFilter { get; set; } = new SummaryFilter();


        [JsonProperty("rounding")]
        public bool Rounding { get; set; } = true;
    }
}