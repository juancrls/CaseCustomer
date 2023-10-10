﻿using Microsoft.AspNetCore.Mvc;
using Domain.Arguments.Customer;
using Domain.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/customers")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
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

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustomer(int id)
        //{
        //    try
        //    {
        //        var success = _customerService.DeleteCustomer(id);

        //        if (!success)
        //        {
        //            return ResponseNotFound();
        //        }

        //        return Response();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResponseException(ex);
        //    }
        //}
    }
}