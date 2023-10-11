using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persist.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Cpf).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(50).IsRequired();
            builder.Property(c => c.BirthDate).IsRequired();
            builder.Property(c => c.Active).IsRequired();
        }
    }
}