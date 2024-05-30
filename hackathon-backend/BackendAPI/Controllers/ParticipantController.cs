using Business.Requests;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;
    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddParticipant([FromBody] ParticipantRequest participantProfile)
    {
        var response = await _participantService.AddParticipant(participantProfile);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
}