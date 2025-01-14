namespace EFSoft.Inventory.Api.CreateInventory;

public class CreateInventoryEndpoint
{
    public static async Task<IResult> CreateInventory(
        [FromBody] CreateInventoryRequest request,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var createInventoryCommand = new CreateInventoryCommand(
            ProductId: request.ProductId,
            StockLeft: request.StockLeft);

        await mediator.Send(
            createInventoryCommand,
            cancellationToken);

        return Results.Ok();
    }
}
