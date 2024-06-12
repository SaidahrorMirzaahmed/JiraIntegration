using JiraIntegration.Models;
using JiraIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraIntegration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JiraController(JiraService _jiraService) : ControllerBase
{

    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        try
        {
            var ticketKey = await _jiraService.CreateJiraTicket(request.Summary, request.Priority, request.UserEmail, request.Link);
            var ticketUrl = $"https://sayidahror.atlassian.net/browse/{ticketKey}";
            return Ok(new { success = true, ticketUrl });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, error = ex.Message });
        }
    }
}

