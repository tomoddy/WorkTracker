using Newtonsoft.Json;

namespace WorkTracker.Clockify
{

    public class Total
    {

        [JsonProperty("totalBillableTime")]
        public int TotalBillableTime { get; set; }
    }
}