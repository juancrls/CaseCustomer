using Microsoft.AspNetCore.Mvc;
using Domain.Arguments.Customer;
using Domain.Interfaces.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("List")]
        public IActionResult ListCustomers()
        {
            try
            {
                var customers = _customerService.List();
                return Response(customers);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("Find/{id}")]
        public IActionResult SelectCustomer(int id)
        {
            try
            {
                var customer = _customerService.Select(id);

                if (customer == null)
                {
                    return ResponseNotFound();
                }

                return Response(customer);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPost("Create")]
        public IActionResult AddCustomer([FromBody] CustomerRequest model)
        {
            try
            {
                var customer = _customerService.Add(model);
                return Response(customer);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateCustomer([FromBody] CustomerRequest model)
        {
            try
            {
                var customer = _customerService.Update(model);

                if (customer == null)
                {
                    return ResponseNotFound();
                }

                return Response(customer);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var response = _customerService.Delete(id);

                if (response == null)
                {
                    return ResponseNotFound();
                }
                return Response(response.Message!);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}
