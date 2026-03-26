using Newtonsoft.Json;

namespace WorkTracker.Clockify
{

    public class SummaryFilter()
    {

        [JsonProperty("groups")]
        public List<string> Groups { get; set; } = ["PROJECT"];


        [JsonProperty("sortColumn")]
        public string SortColumn { get; set; } = "GROUP";


        [JsonProperty("status")]
        public string Status { get; set; } = "ALL";
    }
}