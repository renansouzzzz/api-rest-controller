using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.src.Data.Dtos.Employee;

public class CreateEmployeeDto
{
    [Required]
    public string Name { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }

    public string Phone { get; set; }


    public bool Equals(CreateEmployeeDto? other)
    {
        if (!ReferenceEquals(other, this))
            return false;

        return true;
    }
}
