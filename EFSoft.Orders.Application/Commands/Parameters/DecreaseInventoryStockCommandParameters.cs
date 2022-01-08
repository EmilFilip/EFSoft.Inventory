namespace EFSoft.Orders.Application.Commands.Parameters;

public class DecreaseInventoryStockCommandParameters : ICommand
{
    public DecreaseInventoryStockCommandParameters(
         Guid productId,
         int stockToSubtract)
    {
        ProductId = productId;
        StockToSubtract = stockToSubtract;
    }

    public Guid ProductId { get; }

    public int StockToSubtract { get; }
}
