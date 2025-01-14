namespace EFSoft.Inventory.Api.UpdateInventory;

public class UpdateInventoryEndpoint
{
    public static async Task<IResult> UpdateInventory(
        [FromBody] UpdateInventoryRequest request,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var updateInventoryCommand = new UpdateInventoryCommand(
            ProductId: request.ProductId,
            StockLeft: request.StockLeft);

        await mediator.Send(
            updateInventoryCommand,
            cancellationToken);

        return Results.Ok();
    }
}
