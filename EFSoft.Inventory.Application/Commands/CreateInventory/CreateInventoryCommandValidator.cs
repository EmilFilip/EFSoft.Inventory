namespace EFSoft.Inventory.Application.Commands.CreateInventory;

public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
{
    public CreateInventoryCommandValidator()
    {
        RuleFor(e => e.ProductId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");

        RuleFor(e => e.StockLeft)
            .NotNull().WithMessage("StockLeft cannot be null");
    }
}
