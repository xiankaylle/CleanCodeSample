using App.Core.CustomerService.Commands;
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

            if (!response.IsSuccess)
            {
                return new ObjectResult(response.ErrorMessages)
                {
                    StatusCode = (int)HttpStatusCode.UnprocessableEntity
                };
            }

            return Ok(response);
        }
    }
}
