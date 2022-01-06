namespace EFSoft.Inventory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public InventoryController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor
            ?? throw new ArgumentNullException(nameof(commandExecutor));
        _queryExecutor = queryExecutor
            ?? throw new ArgumentNullException(nameof(queryExecutor));

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok("The Inventory Microservice is working fine");
    }

    [HttpGet]
    [Route("{orderId:guid}")]
    [ProducesResponseType(typeof(GetInventoryQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid productId)
    {
        var results = await _queryExecutor.ExecuteAsync<GetInventoryQueryParameters, GetInventoryQueryResult>(
         new GetInventoryQueryParameters(productId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateInventoryCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateInventoryCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }
}
