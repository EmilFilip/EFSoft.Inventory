namespace EFSoft.Orders.Application.Queries.Parameters;

public class GetInventoryQueryParameters : IQueryParameters
{
    public GetInventoryQueryParameters(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}
