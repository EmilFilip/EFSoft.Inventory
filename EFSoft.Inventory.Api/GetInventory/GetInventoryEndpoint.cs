using EFSoft.Inventory.Application.GetInventory;

namespace EFSoft.Inventory.Api.GetInventory;

public class GetInventoryEndpoint
{
    public static async Task<Results<Ok<GetInventoryQueryResult>, NotFound>> GetInventory(
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
}
