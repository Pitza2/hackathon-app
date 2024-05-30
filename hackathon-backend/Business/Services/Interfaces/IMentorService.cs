using Business.Requests;
using Business.Responses;
using Database.Models;

namespace Business.Services.Interfaces;

public interface IMentorService
{
    public Task<ActionResponse<MentorResponse>> AddMentor(MentorRequest mentor);
}