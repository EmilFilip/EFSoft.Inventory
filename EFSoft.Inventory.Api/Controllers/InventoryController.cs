namespace EFSoft.Inventory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok("The Inventory Microservice is working fine");
    }

    [HttpGet]
    [Route("{productId:guid}")]
    [ProducesResponseType(typeof(GetInventoryQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid productId)
    {
        var results = await _mediator.Send(new GetInventoryQuery(productId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateInventoryCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateInventoryCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }
}
