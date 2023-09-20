namespace EFSoft.Inventory.Application.Commands.DecreaseInventory;

public class DecreaseInventoryStockCommandValidator : AbstractValidator<DecreaseInventoryStockCommand>
{
    public DecreaseInventoryStockCommandValidator()
    {
        RuleFor(e => e.ProductId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");

        RuleFor(e => e.StockToSubtract)
            .NotNull().WithMessage("StockToSubtract cannot be null");
    }
}
