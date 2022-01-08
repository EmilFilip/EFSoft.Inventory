namespace EFSoft.Inventory.Application.Commands.Parameters;

public class UpdateInventoryCommandParameters : ICommand
{
    public UpdateInventoryCommandParameters(
         Guid productId,
         int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; }
    public int StockLeft { get; }
}
