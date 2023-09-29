namespace EFSoft.Inventory.Api.Endpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/inventory");

        group.MapGet("{productId:guid}", Get);
        group.MapPost("", Post);
        group.MapPut("", Put);
    }

    public static async Task<Results<Ok<GetInventoryQueryResult>, NotFound>> Get(
        Guid productId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetInventoryQuery(productId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateInventoryCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateInventoryCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }
}
