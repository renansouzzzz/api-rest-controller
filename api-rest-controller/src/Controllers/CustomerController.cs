using api_rest_controller.Models;
using api_rest_controller.src.Data;
using api_rest_controller.src.Data.Dtos.Customer;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_rest_controller.src.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomerController : ControllerBase

{
    private ApiContext _ApiContext;
    private IMapper _mapper;

    public CustomerController(ApiContext ApiContext, IMapper mapper)
    {
        _ApiContext = ApiContext;
        _mapper = mapper;
    }

    [HttpPost]
    public void AddCustomers(
        [FromBody] CreateCustomerDto customerDto)
    {

        Customer customer = _mapper.Map<Customer>(customerDto);
        _ApiContext.Customers.Add(customer);
        _ApiContext.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        return _ApiContext.Customers;
    }

    [HttpGet("{id}")]
    public ActionResult<Customer?> GetCustomerById(Guid id)
    {
        var customer = _ApiContext
            .Customers
            .FirstOrDefault(customer => customer.Id.Equals(id)); ;

        if (customer is null)
            return NotFound();        

        return Ok(customer);
    }

    [HttpGet("page")]
    public IEnumerable<Customer> GetCustomersByPage([FromQuery] int page)
    {
        page = page * 10 - 10;

        return _ApiContext
            .Customers.Skip(page)
            .Take(10);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCustomer(long id, [FromBody] UpdateCustomerDto uptCustomer)
    {
        var customer = _ApiContext
            .Customers
            .FirstOrDefault(
            customer => customer.Id == id);

        if (customer == null) 
            return NotFound(); 

        _mapper.Map(uptCustomer, customer);

        _ApiContext.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdateCustomerPatch(long id,
        JsonPatchDocument<UpdateCustomerDto> patch)
    {
        var customer = _ApiContext
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
            return ValidationProblem(ModelState);

        _mapper.Map(customerMap, customer);
        _ApiContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("id")]
    public ActionResult DeleteCustomer(long id)
    {
        var customer = _ApiContext
            .Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customer == null) 
            return NotFound(); 

        _ApiContext.Remove(customer);
        
        return NoContent();
    }
}
