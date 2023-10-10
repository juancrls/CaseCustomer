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
        public DateTime BirthDate { get; set; }
        public string Message { get; set; }

        public CustomerResponse(Cpf cpf, string name, string address, bool active, DateTime birthDate)
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
