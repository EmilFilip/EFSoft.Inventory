namespace EFSoft.Orders.Application.Events;

public class OrderPlaced
{
    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}
