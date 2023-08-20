using api_rest_controller.Data;
using api_rest_controller.Data.Dtos.Employee;
using api_rest_controller.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace api_rest_controller.Controllers;

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

        return employees;
    }

    [HttpGet("{id}")]
    public Employee GetById(long id)
    {
        var employee = _context.Employees
            .FirstOrDefault(x => x.Id == id);

        if (employee == null)
            return null!;

        return employee;
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

    [HttpPut("{id}")]
    public Employee Update(long id, [FromBody] UpdateEmployeeDto employee)
    {
        var selectId = _context
            .Employees
            .FirstOrDefault(x => x.Id == id);

        Employee employeeModel = _mapper.Map<Employee>(employee);

        if (selectId != null)
            _mapper.Map(employee, selectId);

        _context.SaveChanges();

        _context.ChangeTracker.Clear();

        return employeeModel;

    }

    [HttpDelete]
    public string Delete(long id)
    {
        var selectEmployee = _context.Employees
            .FirstOrDefault(x => x.Id == id);

        if (selectEmployee != null)
            _context.Employees.Remove(selectEmployee);

        _context.SaveChanges();

        _context.ChangeTracker.Clear();

        return "Funcionário excluído com sucesso!";
    }

    [HttpPost]
    public IEnumerable<Employee> InsertRange([FromBody] IEnumerable<CreateEmployeeDto> employees)
    {
        List<Employee> employeesList = new List<Employee>(); 

        foreach (var employee in employees)
        {
            Employee employeeModel = _mapper.Map<Employee>(employee);
            employeesList.Add(employeeModel);
        }

        _context.Employees.AddRange(employeesList);

        _context.SaveChanges();

        _context.ChangeTracker.Clear();

        return employeesList;
    }
}