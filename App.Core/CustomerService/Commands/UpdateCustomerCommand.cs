using App.Core.Common.Enums;
using App.Core.Common.Extensions;
using App.Core.Common.ResponseWrapper;
using App.Core.Contracts;
using App.Core.CustomerService.TransportModels;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerService.Commands
{
    public class UpdateCustomerCommand : IRequest<ServiceResponse<bool>>
    {
        public CustomerTransport CustomerTransport { get; set; }
    }
       
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ServiceResponse<bool>>
    {

        private readonly IAppDbContext _context;
       
        public UpdateCustomerCommandHandler(IAppDbContext context)
        {
            _context = context;
           
        }
        public async Task<ServiceResponse<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.Where(x => x.Id == request.CustomerTransport.Id).FirstOrDefaultAsync();

            request.CustomerTransport.Adapt(customer);

            int result = await _context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<bool>
            {
                Data = result > 0 ? true : false,
                ResponseStatusCode = ResponseStatusCode.Ok
            };
        }
    }
}
