using Domain.Arguments.Customer;

namespace Domain.Interfaces.Services
{
    public interface CustomerService : IService
    {
        CustomerResponse Add(CustomerRequest request);
        CustomerResponse Update(CustomerRequest request);
        IEnumerable<CustomerResponse> List();
        CustomerResponse Select(int id);
    }
}
