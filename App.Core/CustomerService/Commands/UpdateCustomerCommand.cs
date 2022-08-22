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

    public class UpdateCustomerCommandValidation : IValidationHandler<UpdateCustomerCommand>
    {
        private readonly IAppDbContext _context;
        public UpdateCustomerCommandValidation(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ValidationResult> Validate(UpdateCustomerCommand request)
        {
            if (await _context.Customer.AnyAsync(x => x.Email == request.CustomerTransport.Email))
            {
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Email already exist!");
            }

            if (!await _context.Customer.AnyAsync(x => x.Id == request.CustomerTransport.Id))
            {
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Customer does not exist!");
            }

            if (request.CustomerTransport == null)
            {
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"{nameof(request.CustomerTransport)} can't be null");
            }

            if (string.IsNullOrEmpty(request.CustomerTransport.FirstName))
            {
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"First Name is required!");
            }

            if (!request.CustomerTransport.FirstName.IsStringLengthValid())
            {
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"First Name must have at least 2 characters!");
            }

            if (string.IsNullOrEmpty(request.CustomerTransport.LastName))
            {
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"Last Name is required!");
            }

            if (!request.CustomerTransport.LastName.IsStringLengthValid())
            {
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"Last Name must have at least 2 characters!");
            }
            return Task.FromResult<ValidationResult>(null).Result;
        }
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
