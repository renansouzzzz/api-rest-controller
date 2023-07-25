using System;

public class Employee : IEquatable<Employee>
{ 
	public int Id { get; set; }

	public string Name { get; set; }

	public string Address { get; set; }

	public string City { get; set; }

	public string Region { get; set; }

	public string PostalCode { get; set; }

	public string Country { get; set; }

	public string Phone { get; set; }

    public override bool Equals(object? obj)
    {
		if (ReferenceEquals(null, obj)) 
			return false;

        if (ReferenceEquals(this, obj))
            return true;

		return true;
    }

    public bool Equals(Employee? other)
    {
		if (!ReferenceEquals(other, this))
			return false;

		return true;
    }
}
