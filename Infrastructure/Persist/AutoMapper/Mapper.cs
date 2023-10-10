using AutoMapper;
using Domain.Arguments.Customer;
using Domain.Entities;

namespace Infrastructure.Persist.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}