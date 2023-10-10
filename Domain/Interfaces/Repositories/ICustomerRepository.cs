using Domain.Entities;
using Domain.Entities.Components;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<bool> ExistsWithSameCpf(Cpf cpf);
    }
}