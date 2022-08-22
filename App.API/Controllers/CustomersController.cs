using App.Core.CustomerService.Commands;
using App.Core.CustomerService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(template: nameof(AddCustomer), Name = nameof(AddCustomer))]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerCommand command)
        {
            var response = await _mediator.Send(command);
           
            return Ok(response);
        }
        [HttpGet(template: nameof(GetCustomers), Name = nameof(GetCustomers))]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _mediator.Send(new GetCustomersQuery());

            return Ok(response);
        }

        [HttpGet(template: nameof(GetCustomerById), Name = nameof(GetCustomerById))]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery { CustomerId = id });

            return Ok(response);
        }
    }
}
