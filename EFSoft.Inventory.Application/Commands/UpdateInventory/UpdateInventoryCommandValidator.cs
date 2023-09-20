namespace EFSoft.Inventory.Application.Commands.UpdateInventory;

public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
{
    public UpdateInventoryCommandValidator()
    {
        RuleFor(e => e.ProductId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");

        RuleFor(e => e.StockLeft)
            .NotNull().WithMessage("StockToSubtract cannot be null");
    }
}
