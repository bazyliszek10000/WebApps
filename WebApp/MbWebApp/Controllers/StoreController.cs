using MbStore.Commands.CreateOrder;
using MbStore.Commands.EditOrder;
using MbStore.Queries.GetOrders;
using MbVotingPoll.Commands.CreateVoter;
using MbVotingPoll.Commands.Vote;
using MbVotingPoll.Queries.GetAllVoters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VotersController> _logger;

    public StoreController(IMediator mediator, ILogger<VotersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<GridDataDto> Get([FromQuery]GetOrdersQuery getOrdersQuery)
    {
        return await _mediator.Send(getOrdersQuery);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody]CreateOrderCommand createOrderCommand)
    {
        int id = await _mediator.Send(createOrderCommand);
    
        return Ok(id);
    }
    
    [HttpPut]
    public async Task<ActionResult<int>> Update([FromBody]EditOrderCommand editOrderCommand)
    {
        await _mediator.Send(editOrderCommand);
    
        return Ok();
    }
}