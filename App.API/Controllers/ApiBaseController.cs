using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    /// <summary>
    /// Inherit API Base controller and use Mediator to send requests
    /// </summary>
    public abstract class ApiBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
