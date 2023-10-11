using Domain.Entities.Components;

namespace Domain.Arguments.Customer
{
    public class CustomerResponse : BaseArgument
    {
        public int Id { get; set; }
        public Cpf Cpf { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Message { get; set; }

        public CustomerResponse(Domain.Entities.Customer customer)
        {
            Id = customer.Id;
            Cpf = customer.Cpf;
            Name = customer.Name ?? throw new ArgumentNullException(nameof(Name));
            Address = customer.Address ?? throw new ArgumentNullException(nameof(Address));
            Active = customer.Active;
            BirthDate = customer.BirthDate;
            CreationDate = customer.CreationDate;
            ModificationDate = customer.ModificationDate;
            Message = string.Empty;
        }

        public CustomerResponse(Cpf cpf, string name, string address, bool active, DateOnly birthDate)
        {
            Cpf = cpf;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(name));
            Active = active;
            BirthDate = birthDate;
            Message = string.Empty;
        }

        public CustomerResponse(string message)
        {
            Message = message;
        }
    }
}
