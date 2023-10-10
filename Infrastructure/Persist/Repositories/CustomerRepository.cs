using System.Linq;
using System.Threading.Tasks;
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
    }
}
