using System.Security.Cryptography;
using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(e=> e.Id);

        builder
            .Property(e => e.Id)
            .HasConversion(
                customerId => customerId.Value,
                dbId => CustomerId.Of(dbId));

        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(c => c.Email)
            .HasMaxLength(256);

        builder
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{

    private Action<ComplexPropertyBuilder<Address>> addressBuilder = builder =>
    {
        builder
            .Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.EmailAddress)
            .HasMaxLength(256);

        builder
            .Property(a => a.AddressLine)
            .HasMaxLength(180)
            .IsRequired();

        builder
            .Property(a => a.Country)
            .HasMaxLength(50);

        builder
            .Property(a => a.State)
            .HasMaxLength(50);

        builder
            .Property(a => a.ZipCode)
            .HasMaxLength(5)
            .IsRequired();
    };

    private Action<ComplexPropertyBuilder<Payment>> paymentBuilder = builder =>
    {
        builder
            .Property(p => p.CardName)
            .HasMaxLength(50);
        
        builder
            .Property(p => p.CardNumber)
            .HasMaxLength(24)
            .IsRequired();
        
        builder
            .Property(p => p.Expiration)
            .HasMaxLength(10);

        builder
            .Property(p => p.CVV)
            .HasMaxLength(3);

        builder
            .Property(p => p.PaymentMethod)
            .IsRequired();
    };

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(o => o.Id);
        
        builder
            .Property(o => o.Id)
            .HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId)
            );

        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();
        
        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder
            .ComplexProperty(
                o => o.OrderName,
                nameBuilder =>
                {
                    nameBuilder
                        .Property(n => n.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                });
      
        builder
            .ComplexProperty(
                o => o.SchippingAddress,
                addressBuilder
            );
        
        builder
            .ComplexProperty(
                o => o.BillingAddress,
                addressBuilder
            );

        builder
            .ComplexProperty(
                o => o.Payment,
                paymentBuilder
            );
        
        builder
            .Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus)
            );

        builder.Property(o => o.TotalPrice);
    }
}
