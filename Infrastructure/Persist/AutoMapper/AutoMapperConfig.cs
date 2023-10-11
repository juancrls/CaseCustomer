using AutoMapper;
using Domain.Arguments.Customer;
using Domain.Entities;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Customer, CustomerResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));
    }
}