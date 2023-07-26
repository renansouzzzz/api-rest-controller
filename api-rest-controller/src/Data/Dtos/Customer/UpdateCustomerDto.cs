using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.src.Data.Dtos.Customer;

public class UpdateCustomerDto
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
}
