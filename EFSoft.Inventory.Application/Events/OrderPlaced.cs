namespace EFSoft.Inventory.Application.Events;

public sealed record OrderPlaced(
    Guid CustomerId,
    Guid ProductId,
    int Quantity);
