using MbVotingPoll.Commands.CreateVoter;
using MbVotingPoll.Commands.Vote;
using MbVotingPoll.Queries.GetAllVoters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VotersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VotersController> _logger;

    public VotersController(IMediator mediator, ILogger<VotersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Voter>> GetAll()
    {
        return await _mediator.Send(new GetAllVotersQuery());
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody]CreateVoterCommand createVoterCommand)
    {
        int id = await _mediator.Send(createVoterCommand);

        return Ok(id);
    }
    
    [HttpPut]
    [Route("Vote")]
    public async Task<ActionResult> Vote([FromQuery]VoteCommand voteCommand)
    {
        await _mediator.Send(voteCommand);
        
        return Ok();
    }
}