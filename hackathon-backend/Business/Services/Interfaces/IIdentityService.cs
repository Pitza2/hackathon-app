using Business.Requests;

namespace Business.Services.Interfaces;

public interface IIdentityService
{
    Task<ActionResponse> Login(LoginRequest request);
    Task<ActionResponse<string>> Register(RegisterRequest request);    
}