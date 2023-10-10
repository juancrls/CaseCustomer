using Domain.Entities;
using Infrastructure.Persist.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Persist
{
    public class Context : DbContext
    {
        public Context() : base()
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        private void SetData()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added) entry.Property("CreationDate").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified) entry.Property("ModificationDate").CurrentValue = DateTime.Now;
            }
        }
    }
}
