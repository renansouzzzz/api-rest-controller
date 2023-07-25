using api_rest_controller.Models;
using api_rest_controller.src.Data.Dtos;
using AutoMapper;

namespace api_rest_controller.src.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<Employee, UpdateEmployeeDto>();
    }
}
