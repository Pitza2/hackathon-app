using Business.Requests;
using Business.Responses;

namespace Business.Services.Interfaces;

public interface IParticipantService
{
    public Task<ActionResponse<ParticipantResponse>> AddParticipant(ParticipantRequest participant);

}