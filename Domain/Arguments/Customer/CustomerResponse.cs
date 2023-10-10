using Domain.Entities.Components;

namespace Domain.Arguments.Customer
{
    public class CustomerResponse : BaseArgument
    {
        public Cpf Cpf { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public static explicit operator CustomerResponse(Domain.Entities.Customer entity)
        {
            return new CustomerResponse()
            {
                Cpf = entity.Cpf,
                Name = entity.Name,
                Address = entity.Address,
                BirthDate = entity.BirthDate,
                Active = entity.Active
            };
        }
    }
}