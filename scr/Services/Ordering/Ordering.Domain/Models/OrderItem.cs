namespace Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    internal OrderItem(OrderId orderId, ProductId producId, int quantity, decimal price)
    {
        Id=OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProducId = producId;
        Quantity = quantity;
        Price = price;
    }

    public OrderId OrderId { get; private set;} =default!;
    public ProductId ProducId { get; private set; } =default!;
    public int Quantity { get; private set; } =default!;
    public decimal Price { get; private set; } =default!;
}