using JiraIntegration.Services;

namespace JiraIntegration.Extensions;

public static class CollectionExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJiraService>(sp =>
            new JiraService(
                _jiraDomain: configuration["Jira:Domain"],
                _jiraApiToken: configuration["Jira:ApiToken"],
                _projectKey: configuration["Jira:ProjectKey"]
            )
        );
    }
}
