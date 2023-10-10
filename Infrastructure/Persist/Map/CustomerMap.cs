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

            builder.Property(p => p.Id).HasColumnName("CustomerId").IsRequired();
            builder.Property(p => p.Cpf.Number).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Active).IsRequired();
            // verificar se as datas de criacao/modificacao vao aparecer na classe gerada Migration
        }
    }
}