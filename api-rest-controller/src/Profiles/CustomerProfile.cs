using AutoMapper;
using api_rest_controller.Models;
using api_rest_controller.src.Data.Dtos;

namespace api_rest_controller.src.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
    }
}
