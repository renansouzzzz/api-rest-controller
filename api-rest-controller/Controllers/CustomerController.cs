using api_rest_controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_rest_controller.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase

{ 
    private static List<Customer> customers = new List<Customer>();

    [HttpGet]
    public List<Customer> GetCustomers()
    {
        return customers;
    }

    [HttpPost]
    public void AddCustomers([FromBody]Customer customer)
    {
        customers.Add(customer);
        
    } 
}
