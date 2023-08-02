using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.Data.Dtos.Customer;

public class CreateCustomerDto
{

    [Required(ErrorMessage = "O nome é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A idade é obrigatória!")]
    public int Age { get; set; }
    [Required(ErrorMessage = "O email é obrigatório!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O endereço é obrigatório!")]
    public string Address { get; set; }
    [Required(ErrorMessage = "A cidade é obrigatória!")]
    public string City { get; set; }
}
