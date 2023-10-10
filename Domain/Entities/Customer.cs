using Domain.Entities.Components;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(Cpf cpf, string name, string address, bool active, DateTime birthDate) : this()
        { 
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException(nameof(name));

            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Name = name;
            Address = address;
            Active = active;
            BirthDate = birthDate;
        }
        public Cpf Cpf { get; protected set; }
        public string Name { get; protected set; } = default!;
        public string Address { get; protected set; } = default!;
        public bool Active { get; protected set; }
        public DateTime BirthDate { get; protected set; }

        public virtual void Update(Cpf cpf, string name, string address, bool active, DateTime birthDate)
        {
            Cpf = cpf;
            Name = name;
            Address = address;
            Active = active;
            BirthDate = birthDate;

            SetModificationDate(DateTime.Now);
        }
    }
}