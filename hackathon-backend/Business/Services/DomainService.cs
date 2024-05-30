using Business.Services.Interfaces;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class DomainService : IDomainService
{
    private readonly HackDbContext _hackDbContext;

    public DomainService(HackDbContext hackDbContext)
    {
        _hackDbContext = hackDbContext;
    }

    public async Task<ActionResponse<List<Domain>>> GetDomains()
    {
        var response = new ActionResponse<List<Domain>>();
        var item = await _hackDbContext.Domains.ToListAsync();
        response.Item = item;
        return response;
    }
}