using Domain.Entities;
using Domain.Entities.Components;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<bool> ExistsWithSameCpf(Cpf cpf, int id);

        Customer? FindById(int id);
        IEnumerable<Customer> FindAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}