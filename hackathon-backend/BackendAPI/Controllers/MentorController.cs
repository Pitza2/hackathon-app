using Business.Requests;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MentorController : ControllerBase
{
    private readonly IMentorService _mentorService;
    public MentorController(IMentorService mentorService)
    {
        _mentorService = mentorService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddMentor([FromBody] MentorRequest mentorProfile)
    {
        var response = await _mentorService.AddMentor(mentorProfile);
        if (response.HasErrors())
        {
            return BadRequest(response.Errors);
        }

        return Ok(response.Item);
    }
    
    
}