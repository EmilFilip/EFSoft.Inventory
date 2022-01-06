namespace EFSoft.Orders.Domain.Models;

public class InventoryModel
{
    public InventoryModel(
       Guid productInventoryId,
       Guid productId,
       int stockLeft)
    {
        ProductInventoryId = productInventoryId;
        ProductId = productId;
        StockLeft = stockLeft;
    }
    public InventoryModel(
        Guid productId,
        int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public static InventoryModel CreateNew(
        Guid productId,
        int stockLeft)
    {
        return new InventoryModel(
            productInventoryId: Guid.NewGuid(),
            productId: productId,
            stockLeft: stockLeft);
    }

    public Guid ProductInventoryId { get; set; }

    public Guid ProductId { get; set; }

    public int StockLeft { get; set; }
}
