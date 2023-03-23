using api_rest_controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_rest_controller.src.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomerController : ControllerBase

{
    private static int id = 1;
    private static List<Customer> customers = new List<Customer>();

    [HttpPost]
    public void AddCustomers([FromBody] Customer customer)
    {
        customer.Id = id++;
        customers.Add(customer);
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        return customers;
    }

    [HttpGet("{id}")]
    public Customer? GetCustomerById(long id)
    {
        return customers.FirstOrDefault(customer => customer.Id.Equals(id));
    }

    [HttpGet("page")]
    public IEnumerable<Customer> GetCustomersByPage([FromQuery] int page)
    {
        if (page <= 0 || page > customers.Count) { return customers; }
        else if (page == 1) { return customers.Take(10); }

        else
        {
            page = page * 10 - 10;
        }
        return customers.Skip(page).Take(10);
    }
}
