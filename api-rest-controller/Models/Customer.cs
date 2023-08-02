using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.Models;

public class Customer : IEquatable<Customer>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return true;
    }

    public bool Equals(Customer? other)
    {
        if (!ReferenceEquals(other, this))
            return false;

        return true;
    }
}
