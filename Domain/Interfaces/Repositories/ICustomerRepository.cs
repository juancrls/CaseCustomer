using Domain.Entities;
using Domain.Entities.Components;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<bool> ExistsWithSameCpf(Cpf cpf);

        // testar remover todos esse métodos pra ver se ainda vai funcionar com
        // os métodos do IBaseRepository

        Customer? FindById(int id);
        IEnumerable<Customer> FindAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}