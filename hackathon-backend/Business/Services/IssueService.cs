using Business.Requests;
using Business.Services.Interfaces;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class IssueService : IIssueService
{
    private readonly HackDbContext _hackDbContext;

    public IssueService(HackDbContext hackDbContext)
    {
        _hackDbContext = hackDbContext;
    }

    public async Task<ActionResponse<List<Issue>>> GetIssues(string userId)
    {
        var result = new ActionResponse<List<Issue>>();
        var profile = _hackDbContext.MentorProfiles.FirstOrDefault(x => x.User.Id == userId);
        if (profile is not null)
        {
            var issues = await _hackDbContext.Issues
                .Where(x => x.Domains.Any(y => profile.Domains.Contains(y)) && x.IsSolved == false).ToListAsync();
            result.Item = issues;
        }
        else
        {
            var participantProfile = _hackDbContext.ParticipantProfiles.FirstOrDefault(x => x.User.Id == userId);
            var issues = await _hackDbContext.Issues.Where(x => x.Profile == participantProfile).ToListAsync();
            result.Item = issues;
        }

        return result;
    }

    public async Task<ActionResponse<Issue>> AddIssue(IssueRequest issue)
    {
        var item = new Issue
        {
            Id = Guid.NewGuid().ToString(),
            Title = issue.Title,
            Description = issue.Description,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            IsSolved = false,
            Profile = _hackDbContext.ParticipantProfiles.Find( issue.ParticipantProfileId),
            Domains = issue.DomainIds.Select(x => _hackDbContext.Domains.Find(x)).ToList(),
            
        };
        _hackDbContext.Issues.Add(item);
        await _hackDbContext.SaveChangesAsync();

        return new ActionResponse<Issue> { Item = item };
    }

    public async Task<ActionResponse<Issue>> DeleteIssue(string id)
    {
        var issue = await _hackDbContext.Issues.FindAsync(id);
        if (issue == null)
        {
            return new ActionResponse<Issue> { Item = new Issue() };
        }

        _hackDbContext.Issues.Remove(issue);
        await _hackDbContext.SaveChangesAsync();

        return new ActionResponse<Issue> { Item = issue };
    }

    public async Task<ActionResponse<Issue>> UpdateIssue(string id, IssueRequest issue)
    {
        var existingIssue = await _hackDbContext.Issues.FindAsync(id);
        if (existingIssue == null)
        {
            return new ActionResponse<Issue> {};
        }

        var item = new Issue
        {
            Id = Guid.NewGuid().ToString(),
            Title = issue.Title,
            Description = issue.Description,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            IsSolved = false,
            Profile = _hackDbContext.ParticipantProfiles.Find( issue.ParticipantProfileId),
            Domains = issue.DomainIds.Select(x => _hackDbContext.Domains.Find(x)).ToList(),
        };
        
        _hackDbContext.Issues.Remove(existingIssue);
        _hackDbContext.Issues.Add(item);
        await _hackDbContext.SaveChangesAsync();

        return new ActionResponse<Issue> { Item = existingIssue };
    }
}