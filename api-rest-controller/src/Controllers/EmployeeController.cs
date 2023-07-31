using api_rest_controller.src.Data;
using api_rest_controller.src.Data.Dtos.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace api_rest_controller.src.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeeController
{
    private ApiContext _context;
    private IMapper _mapper;

    public EmployeeController(ApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Employee> Get()
    {
        var employees = _context.Employees;

        ImmutableArray<Employee> array = ImmutableArray.Create<Employee>();

        foreach (var employee in employees)
            array = array.Add(employee);

        return _context.Employees;
    }

    [HttpPost]
    public CreateEmployeeDto Insert([FromBody] CreateEmployeeDto employee)
    {
        Employee employeeModel = _mapper
            .Map<Employee>(employee);


        _context.Employees.Add(employeeModel);

        _context.SaveChanges();

        _context.ChangeTracker.Clear();

        return employee;
    }
}
