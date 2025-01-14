namespace EFSoft.Inventory.Api.CreateInventory;

public class CreateInventoryRequestValidator : AbstractValidator<CreateInventoryRequest>
{
    public CreateInventoryRequestValidator()
    {
        _ = RuleFor(e => e.ProductId)
            .NotNull().WithMessage("ProductId cannot be null")
            .NotEmpty().WithMessage("ProductId cannot be empty");
    }
}
