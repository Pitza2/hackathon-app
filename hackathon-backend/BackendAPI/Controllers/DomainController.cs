using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DomainController : ControllerBase
{
    private readonly IDomainService _domainService;
    public DomainController(IDomainService domainService)
    {
        _domainService = domainService;
    }
    [HttpGet]
    public async Task<IActionResult> GetDomains()
    {
        var response = await _domainService.GetDomains();
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
}