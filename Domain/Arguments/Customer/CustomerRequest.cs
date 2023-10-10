using Domain.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Arguments.Customer
{
    public class CustomerRequest : BaseArgument
    {
        public Cpf Cpf { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}