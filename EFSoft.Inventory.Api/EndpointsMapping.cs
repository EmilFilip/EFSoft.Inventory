namespace EFSoft.Inventory.Api;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/inventory").WithTags("Inventory");

        _ = group.MapGet("/{productId:guid}", GetInventoryEndpoint.GetInventory);

        _ = group.MapPost("/", CreateInventoryEndpoint.CreateInventory);

        _ = group.MapPut("/", UpdateInventoryEndpoint.UpdateInventory);
    }
}
