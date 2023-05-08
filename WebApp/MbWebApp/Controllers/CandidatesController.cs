using MbDB.Entities;
using MbVotingPoll.Commands.CreateCandidate;
using MbVotingPoll.Commands.CreateVoter;
using MbVotingPoll.Queries.GetAllCandidates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace MbWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CandidatesController> _logger;

    public CandidatesController(IMediator mediator, ILogger<CandidatesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Candidate>> GetAll()
    {
        return await _mediator.Send(new GetAllCandidatesQuery());
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody]CreateCandidateCommand candidate)
    {
        int candidateId = await _mediator.Send(candidate);
        return candidateId;
    }
}