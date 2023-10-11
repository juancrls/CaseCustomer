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
        public string? Message { get; set; }

        public CustomerResponse()
        {
        }

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
        }

        public CustomerResponse(string message)
        {
            Message = message;
        }
    }
}
