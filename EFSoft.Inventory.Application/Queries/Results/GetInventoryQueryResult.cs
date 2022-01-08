namespace EFSoft.Inventory.Application.Queries.Results;

public class GetInventoryQueryResult : IQueryResult
{
    public GetInventoryQueryResult(
        Guid productId,
        int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; set; }

    public int StockLeft { get; set; }
}