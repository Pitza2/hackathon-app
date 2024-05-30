using Database.Models;

namespace Business.Services.Interfaces;

public interface IDomainService
{
    public Task<ActionResponse<List<Domain>>> GetDomains();
}