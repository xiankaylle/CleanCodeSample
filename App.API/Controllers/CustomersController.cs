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
    public class CustomersController : ApiBaseController
    {
        //private readonly IMediator _mediator;
        //public CustomersController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        [HttpPost(template: nameof(AddCustomer), Name = nameof(AddCustomer))]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand command)
        {
            var response = await Mediator.Send(command);
           
            return Ok(response);
        }
        [HttpGet(template: nameof(GetCustomers), Name = nameof(GetCustomers))]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await Mediator.Send(new GetCustomersQuery());

            return Ok(response);
        }

        [HttpGet(template: nameof(GetCustomersPaging), Name = nameof(GetCustomersPaging))]
        public async Task<IActionResult> GetCustomersPaging([FromQuery] GetCustomersPagingQuery getCustomersPagingQuery)
        {
            var response = await Mediator.Send(getCustomersPagingQuery);

            return Ok(response);
        }

        [HttpGet(template: nameof(GetCustomerById), Name = nameof(GetCustomerById))]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await Mediator.Send(new GetCustomerByIdQuery { CustomerId = id });

            return Ok(response);
        }
        [HttpPatch(template: nameof(UpdateCustomerInfo), Name = nameof(UpdateCustomerInfo))]
        public async Task<IActionResult> UpdateCustomerInfo([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var response = await Mediator.Send(updateCustomerCommand);

            return Ok(response);
        }
    }
}
