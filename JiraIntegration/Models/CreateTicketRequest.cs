namespace JiraIntegration.Models;

public class CreateTicketRequest
{
    public string Summary { get; set; }
    public string Priority { get; set; }
    public string UserEmail { get; set; }
    public string Link { get; set; }
}
