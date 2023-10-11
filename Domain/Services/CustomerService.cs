using AutoMapper;
using AutoMapper.Execution;
using Common.Extensions;
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
            var existsWithSameCpf = _customerRepository.ExistsWithSameCpf(request.Cpf, request.Id);

            if(!request.Cpf.Number.IsCpf())
            {
                throw new InvalidOperationException($"The CPF '{request.Cpf.Number}' is invalid.");
            }

            if (existsWithSameCpf.Result)
            {
                throw new InvalidOperationException("Customer already exists.");
            }


            var customer = new Customer
            (
                request.Cpf,
                request.Name,
                request.Address,
                request.Active,
                request.BirthDate
            );

            _customerRepository.Add(customer);

            return new CustomerResponse(customer);
        }

        public CustomerResponse Update(CustomerRequest request)
        {
            var existingCustomer = _customerRepository.FindById(request.Id);

            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            if (!request.Cpf.Number.IsCpf())
            {
                throw new InvalidOperationException($"The CPF '{request.Cpf.Number}' is invalid.");
            }

            var existsWithSameCpf = _customerRepository.ExistsWithSameCpf(request.Cpf, request.Id);

            if (existsWithSameCpf.Result)
            {
                throw new InvalidOperationException("Customer already exists.");
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
                throw new InvalidOperationException("Customer not found.");
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
                throw new InvalidOperationException("Customer not found.");
            }

            return _mapper.Map<CustomerResponse>(_customerRepository.FindById(id));
        }
    }
}