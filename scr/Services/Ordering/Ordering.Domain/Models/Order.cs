namespace Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
   private readonly List<OrderItem> _orderItems = new();

   public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

   public CustomerId Customer { get; private set; } = default!;
   public OrderName OrderName { get; private set; } = default!;

   public Address SchippingAddress { get; private set; } = default!;
   public Address BillingAddress { get; private set; } = default!;

   public Payment Payment { get; private set; } = default!;

   public OrderStatus Status { get; private set; } = OrderStatus.Pending;

   public decimal TotalPrice 
   {
      get => _orderItems.Sum(x => x.Price * x.Quantity); 
      private set {}
   }

}
