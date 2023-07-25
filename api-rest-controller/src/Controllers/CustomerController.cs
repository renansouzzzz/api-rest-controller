using api_rest_controller.Models;
using api_rest_controller.src.Data;
using api_rest_controller.src.Data.Dtos.Customer;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api_rest_controller.src.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomerController : ControllerBase

{
    private CustomerContext _customerContext;
    private IMapper _mapper;

    public CustomerController(CustomerContext customerContext, IMapper mapper)
    {
        _customerContext = customerContext;
        _mapper = mapper;
    }

    [HttpPost]
    public void AddCustomers(
        [FromBody] CreateCustomerDto customerDto)
    {

        Customer customer = _mapper.Map<Customer>(customerDto);
        _customerContext.Customers.Add(customer);
        _customerContext.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        return _customerContext.Customers;
    }

    [HttpGet("{id}")]
    public Customer? GetCustomerById(long id)
    {
        return _customerContext
            .Customers
            .FirstOrDefault(customer => customer.Id.Equals(id));
    }

    [HttpGet("page")]
    public IEnumerable<Customer> GetCustomersByPage([FromQuery] int page)
    {
        page = page * 10 - 10;

        return _customerContext
            .Customers.Skip(page)
            .Take(10);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(long id, [FromBody] UpdateCustomerDto uptCustomer)
    {
        var customer = _customerContext
            .Customers
            .FirstOrDefault(
            customer => customer.Id == id);

        if (customer == null) { return NotFound(); }

        _mapper.Map(uptCustomer, customer);
        _customerContext.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCustomerPatch(long id,
        JsonPatchDocument<UpdateCustomerDto> patch)
    {
        var customer = _customerContext
            .Customers
            .FirstOrDefault(
            customer => customer.Id == id);

        var customerMap = _mapper.Map<UpdateCustomerDto>(customer);

        patch.ApplyTo(customerMap, (Microsoft
            .AspNetCore
            .JsonPatch
            .Adapters
            .IObjectAdapter)ModelState);

        if (!TryValidateModel(customerMap))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(customerMap, customer);
        _customerContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("id")]
    public IActionResult DeleteCustomer(long id)
    {
        var customer = _customerContext.Customers.FirstOrDefault(
            customer => customer.Id == id);

        if(customer == null) { return NotFound(); }

        _customerContext.Remove(customer);
        
        return NoContent();
    }
}
