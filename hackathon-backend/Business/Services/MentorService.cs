using Business.Requests;
using Business.Responses;
using Business.Services.Interfaces;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class MentorService : IMentorService
{
    private readonly HackDbContext _hackDbContext;
    public MentorService(HackDbContext hackDbContext)
    {
        _hackDbContext = hackDbContext;
    }
    
    public async Task<ActionResponse<MentorResponse>> AddMentor(MentorRequest mentor)
    {
        var response = new ActionResponse<MentorResponse>();
        var user = await _hackDbContext.Users.FirstAsync(u => u.Id == mentor.UserId);
        var mentorProfile = new MentorProfile
        {
            Id = Guid.NewGuid().ToString(),
            User = user,
            Domains = new List<Domain>(),
        };
        foreach (var domainId in mentor.DomainIds)
        {
            var domain = await _hackDbContext.Domains.FindAsync(domainId);
            if (domain is not null)
            {
                mentorProfile.Domains.Add(domain);
            }
        }
        
        var dbMentor = await _hackDbContext.MentorProfiles.AddAsync(mentorProfile);
        await _hackDbContext.SaveChangesAsync();
        
        var userResponse = new UserResponse()
        {
            Id = dbMentor.Entity.User.Id,
            Email = dbMentor.Entity.User.Email,
            FirstName = dbMentor.Entity.User.FirstName,
            LastName = dbMentor.Entity.User.LastName,
            IsMentor = true,
        };
        var responseItem = new MentorResponse()
        {
            Id = dbMentor.Entity.Id,
            User = userResponse,
            Domains = dbMentor.Entity.Domains
        };
        
        response.Item = responseItem;
        return response;
    }
    
}