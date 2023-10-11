using Domain.Arguments.Customer;

namespace Domain.Interfaces.Services
{
    public interface ICustomerService : IService
    {
        CustomerResponse Add(CustomerRequest request);
        CustomerResponse Update(CustomerRequest request);
        CustomerResponse Delete (int id);
        IEnumerable<CustomerResponse> List();
        CustomerResponse Select(int id);
    }
}