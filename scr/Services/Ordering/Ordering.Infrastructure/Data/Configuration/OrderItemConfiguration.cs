namespace Ordering.Infrastructure.Data.Configuration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(oi => oi.Id);
        
        builder
            .Property(oi => oi.Id)
            .HasConversion(
                OrderItemId => OrderItemId.Value,
                dbId => OrderItemId.Of(dbId)
            );
        
        builder
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProducId);
        
        builder
            .Property(io => io.Quantity)
            .IsRequired();
        
        builder
            .Property(oi => oi.Price)
            .IsRequired();
    }
}