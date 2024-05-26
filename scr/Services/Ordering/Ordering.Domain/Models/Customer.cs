namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } =default!;
    public string Email { get; private set; } = default!;

    public static Customer create(CustomerId customerId, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        Customer customer = new Customer
        {
            Name = name,
            Email = email
        };

        return customer;
    }

}
