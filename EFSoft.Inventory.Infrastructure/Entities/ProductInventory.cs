namespace EFSoft.Inventory.Infrastructure.Entities;

[Index(nameof(ProductId), IsUnique = true)]
public class ProductInventory
{
    [Key]
    public Guid ProductInventoryId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    public int StockLeft { get; set; }

    public DateTime? UpdatedAt { get; set; }
}