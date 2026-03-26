using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WorkTracker.Clockify;

namespace WorkTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoursController : ControllerBase
    {
        private string? WorkspaceId { get; set; }

        private string? ApiKey { get; set; }

        private HttpClient Client { get; set; }

        private HttpRequestMessage RequestMessage { get; set; }

        private static DateTime Start => new(DateTime.Now.Year, DateTime.Now.Month, 1);

        private static DateTime End => new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddMilliseconds(-1);

        public HoursController(IConfiguration configuration)
        {
            WorkspaceId = configuration["workspaceId"];
            ApiKey = configuration["apiKey"];

            Client = new HttpClient();
            RequestMessage = new HttpRequestMessage(HttpMethod.Post, $"https://reports.api.clockify.me/v1/workspaces/{WorkspaceId}/reports/summary");
            RequestMessage.Headers.Add("X-Api-Key", ApiKey);
        }

        [HttpGet(Name = "Hours")]
        public float? Index()
        {
            RequestMessage.Content = new StringContent(JsonConvert.SerializeObject(new SummaryReportRequest(End, Start)), Encoding.UTF8, "application/json");
            HttpResponseMessage response = Client.SendAsync(RequestMessage).Result;
            response.EnsureSuccessStatusCode();

            int? totalBillableTime = JsonConvert.DeserializeObject<SummaryReportResponse>(response.Content.ReadAsStringAsync().Result)?.Totals?.FirstOrDefault()?.TotalBillableTime;
            return totalBillableTime is null ? throw new NullReferenceException() : (float)totalBillableTime.Value / 3600;
        }
    }
}