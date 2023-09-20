namespace EFSoft.Inventory.Application.Queries.GetInventory;

public class GetInventoryQueryValidator : AbstractValidator<GetInventoryQuery>
{
    public GetInventoryQueryValidator()
    {
        RuleFor(e => e.ProductId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
    }
}