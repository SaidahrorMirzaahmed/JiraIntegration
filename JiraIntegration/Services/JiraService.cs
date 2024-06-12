namespace JiraIntegration.Services;

// Services/JiraService.cs
using RestSharp;
using System;
using System.Threading.Tasks;

public class JiraService(string _jiraDomain, string _jiraApiToken, string _projectKey) : IJiraService
{
    public async Task<string> CreateJiraTicket(string summary, string priority, string userEmail, string link)
    {
        var _client = new RestClient(new Uri($"https://{_jiraDomain}"));
        var request = new RestRequest("rest/api/2/issue", Method.Post);
        request.AddHeader("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{userEmail}:{_jiraApiToken}"))}");
        request.AddHeader("Content-Type", "application/json");

        var body = new
        {
            fields = new
            {
                project = new { key = _projectKey },
                summary = summary,
                description = $"Reported by: {userEmail}\nLink: {link}",
                issuetype = new { name = "Task" },
                priority = new { name = priority },
                collection = userEmail,  // Adjust according to your custom field ID for "Collection"
                Link = link  // Adjust according to your custom field ID for "Link"
            }
        };

        request.AddJsonBody(body);

        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            var ticketKey = Newtonsoft.Json.Linq.JObject.Parse(response.Content)["key"].ToString();
            return ticketKey;
        }

        throw new Exception("Failed to create Jira ticket: " + response.ErrorMessage);
    }
}

