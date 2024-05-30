using Business.Requests;
using Database.Models;

namespace Business.Services.Interfaces;

public interface IIssueService
{
    public Task<ActionResponse<List<Issue>>> GetIssues(string userId);
    public Task<ActionResponse<Issue>> AddIssue(IssueRequest issue);
    public Task<ActionResponse<Issue>> DeleteIssue(string id);
    public Task<ActionResponse<Issue>> UpdateIssue(string id, IssueRequest issue);
}