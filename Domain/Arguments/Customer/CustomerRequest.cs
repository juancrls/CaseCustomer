using Domain.Entities.Components;

namespace Domain.Arguments.Customer
{
    public class CustomerRequest : BaseArgument
    {
        public Cpf Cpf { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Active { get; set; }
    }
}