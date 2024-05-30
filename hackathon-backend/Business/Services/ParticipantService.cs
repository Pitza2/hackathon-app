using Business.Requests;
using Business.Responses;
using Business.Services.Interfaces;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class ParticipantService : IParticipantService
{
    private readonly HackDbContext _hackDbContext;
    public ParticipantService(HackDbContext dbContext)
    {
        _hackDbContext = dbContext;
    }

    public async Task<ActionResponse<ParticipantResponse>> AddParticipant(ParticipantRequest participant)
    {
        var response = new ActionResponse<ParticipantResponse>();
        var user = await _hackDbContext.Users.FirstAsync(u => u.Id == participant.UserId);
        var participantProfile = new ParticipantProfile()
        {
            Id = Guid.NewGuid().ToString(),
            User = user,
            Domains = new List<Domain>(),
            Table = participant.Table
        };
        foreach (var domainId in participant.DomainIds)
        {
            var domain = await _hackDbContext.Domains.FindAsync(domainId);
            if (domain is not null)
            {
                participantProfile.Domains.Add(domain);
            }
        }
        
        var dbMentor = await _hackDbContext.ParticipantProfiles.AddAsync(participantProfile);
        await _hackDbContext.SaveChangesAsync();
        
        var userResponse = new UserResponse()
        {
            Id = dbMentor.Entity.User.Id,
            Email = dbMentor.Entity.User.Email,
            FirstName = dbMentor.Entity.User.FirstName,
            LastName = dbMentor.Entity.User.LastName,
            IsMentor = false
        };
        var responseItem = new ParticipantResponse()
        {
            Id = dbMentor.Entity.Id,
            User = userResponse,
            Domains = dbMentor.Entity.Domains,
            Table = dbMentor.Entity.Table
        };
        
        response.Item = responseItem;
        return response;
    }
}
