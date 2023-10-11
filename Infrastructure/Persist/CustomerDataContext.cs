using Domain.Entities;
using Domain.Entities.Components;
using Infrastructure.Persist.Map;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persist
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext() : base() { } 

        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }
        // verificar como utilizar dados de um json (para n expor no repositório do github) ou entao como fazer funcionar pelo startup.cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db;User Id=postgres;Password=1234;");

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Customer>()
               .Property(c => c.Cpf)
               .HasConversion(cpf => cpf.Number, cpfNumber => new Cpf(cpfNumber));

            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetData();
            return base.SaveChanges();
        }

        private void SetData()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added) entry.Property("CreationDate").CurrentValue = DateOnly.FromDateTime(DateTime.Now);
                if (entry.State == EntityState.Modified) entry.Property("ModificationDate").CurrentValue = DateOnly.FromDateTime(DateTime.Now);
            }
        }
    }
}
