using api_rest_controller.Data.Dtos.Employee;
using AutoMapper;

namespace api_rest_controller.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<Employee, UpdateEmployeeDto>();
    }
}
