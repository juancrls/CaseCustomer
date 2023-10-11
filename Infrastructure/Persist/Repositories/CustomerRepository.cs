using System.Linq;
using System.Threading.Tasks;
using Domain.Arguments.Customer;
using Domain.Entities;
using Domain.Entities.Components;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persist.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        protected readonly CustomerDataContext _context;

        public CustomerRepository(CustomerDataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsWithSameCpf(Cpf cpf)
        {
            return await _context.Customers.AnyAsync(c => c.Cpf == cpf);
        }

        public Customer? FindById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);

            return customer;
        }

        public IEnumerable<Customer> FindAll()
        {
            return _context.Customers.ToList();
        }

        public void Delete(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Add(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
