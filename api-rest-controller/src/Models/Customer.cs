using System.ComponentModel.DataAnnotations;

namespace api_rest_controller.Models;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
}
