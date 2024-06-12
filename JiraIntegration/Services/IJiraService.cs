namespace JiraIntegration.Services;

public interface IJiraService
{
    Task<string> CreateJiraTicket(string summary, string priority, string userEmail, string link);
}
