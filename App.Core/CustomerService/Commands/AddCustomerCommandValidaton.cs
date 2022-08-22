using App.Core.Common.Enums;
using App.Core.Common.Extensions;
using App.Core.Common.ResponseWrapper;
using App.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerService.Commands
{
    public class AddCustomerCommandValidaton : IValidationHandler<AddCustomerCommand>
    {
        private readonly IAppDbContext _context;

        public AddCustomerCommandValidaton(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(AddCustomerCommand request)
        {
            if (await _context.Customer.AnyAsync(x => x.Email == request.CustomerTransport.Email))
            {
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Email already exist!");
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

}
