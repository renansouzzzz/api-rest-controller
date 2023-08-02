using AutoMapper;
using api_rest_controller.Models;
using api_rest_controller.Data.Dtos.Customer;

namespace api_rest_controller.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, UpdateCustomerDto>();
    }
}
