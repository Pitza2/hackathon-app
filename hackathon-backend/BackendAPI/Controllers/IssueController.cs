using Business.Requests;
using Business.Services.Interfaces;
using Database.Models;

namespace BackendAPI.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    private readonly IIssueService _issueService;
    public IssueController(IIssueService issueService)
    {
        _issueService = issueService;
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> GetIssues(string userId)
    {
        var response = await _issueService.GetIssues(userId);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddIssue([FromBody] IssueRequest issue)
    {
        var response = await _issueService.AddIssue(issue);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteIssue(string id)
    {
        var response = await _issueService.DeleteIssue(id);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateIssue(string id, [FromBody] IssueRequest issue)
    {
        var response = await _issueService.UpdateIssue(id, issue);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
}
