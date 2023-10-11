using AutoMapper;
using Domain.Arguments.Customer;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService() { }

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public CustomerResponse Add(CustomerRequest request)
        {
            // ADICIONAR VALIDACOES NO CPF, NAME E ADDRESS PARA UTILIZAR MENSAGENS (TALVEZ USAR AS MSGS DO RESOURCES)
            var customer = new Customer
            (
                request.Cpf,
                request.Name,
                request.Address,
                request.Active,
                request.BirthDate
            );

            _customerRepository.Add(customer);

            return new CustomerResponse(customer.Cpf, customer.Name, customer.Address, customer.Active, customer.BirthDate);
        }

        public CustomerResponse Update(CustomerRequest request)
        {
            var existingCustomer = _customerRepository.FindById(request.Id);

            if (existingCustomer == null)
            {
                return new CustomerResponse("Customer not found.");
            }

            existingCustomer.Update(request.Cpf, request.Name, request.Address, request.Active, request.BirthDate);

            _customerRepository.Update(existingCustomer);

            return new CustomerResponse(existingCustomer);
        }

        public CustomerResponse Delete(int id)
        {
            var existingCustomer = _customerRepository.FindById(id);

            if (existingCustomer == null)
            {
                return new CustomerResponse("Customer not found.");
            }

            _customerRepository.Delete(existingCustomer);

            return new CustomerResponse("Customer deleted successfully");
        }

        public IEnumerable<CustomerResponse> List()
        {
            var customers = _customerRepository.FindAll();

            return customers.Select(customer => new CustomerResponse(customer));
        }

        public CustomerResponse Select(int id)
        {
            if (id == 0)
            {
                return new CustomerResponse("Customer not found."); // TROCAR POR MENSAGEM
            }

            return _mapper.Map<CustomerResponse>(_customerRepository.FindById(id));
        }
    }
}