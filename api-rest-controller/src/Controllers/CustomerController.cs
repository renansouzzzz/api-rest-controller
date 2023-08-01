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
    private ApiContext _apiContext;
    private IMapper _mapper;

    public CustomerController(ApiContext apiContext, IMapper mapper)
    {
        _apiContext = apiContext;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<Customer> AddCustomers(
        [FromBody] CreateCustomerDto customerDto)
    {

        Customer customer = _mapper.Map<Customer>(customerDto);
        _apiContext.Customers.Add(customer);
        _apiContext.SaveChanges();

        return Ok(customer);
    }

    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        return _apiContext.Customers;
    }

    [HttpGet("{id}")]
    public ActionResult<Customer?> GetById(Guid id)
    {
        var customer = _apiContext
            .Customers
            .FirstOrDefault(customer => customer.Id.Equals(id));

        if (customer is null)
            return NotFound();        

        return Ok(customer);
    }

    [HttpGet("page")]
    public IEnumerable<Customer> GetByPage([FromQuery] int page)
    {
        page = page * 10 - 10;

        return _apiContext
            .Customers.Skip(page)
            .Take(10);
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, [FromBody] UpdateCustomerDto uptCustomer)
    {
        var customer = _apiContext
            .Customers
            .FirstOrDefault(
            customer => customer.Id == id);

        if (customer == null) 
            return NotFound(); 

        _mapper.Map(uptCustomer, customer);

        _apiContext.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdatePatch(long id,
        JsonPatchDocument<UpdateCustomerDto> patch)
    {
        var customer = _apiContext
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
        _apiContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("id")]
    public ActionResult Delete(long id)
    {
        var customer = _apiContext
            .Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customer == null) 
            return NotFound(); 

        _apiContext.Remove(customer);
        
        return NoContent();
    }
}
