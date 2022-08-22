using App.Core.Common.Enums;
using App.Core.Common.Extensions;
using App.Core.Common.ResponseWrapper;
using App.Core.Contracts;
using App.Core.CustomerService.TransportModels;
using App.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.CustomerService.Commands
{
    public class AddCustomerCommand : IRequest<ServiceResponse<bool>>
    {
        public CustomerTransport CustomerTransport { get; set; }

    }

    public class AddCustomerCommandValidator : IValidationHandler<AddCustomerCommand>
    {
        private readonly IAppDbContext _context;

        public AddCustomerCommandValidator(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ValidationResult> Validate(AddCustomerCommand request)
        {
            if (await _context.Customer.AnyAsync(x => x.Email == request.CustomerTransport.Email)) { 
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Email already exist!");
            }

            if (request.CustomerTransport == null) {             
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"{nameof(request.CustomerTransport)} can't be null");
            }

            if (!request.CustomerTransport.FirstName.IsStringLengthValid()) { 
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"First Name must have at least 2 characters!");
            }

            if (string.IsNullOrEmpty(request.CustomerTransport.FirstName)) { 
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"First Name is required!");
            }

            if (!request.CustomerTransport.LastName.IsStringLengthValid()) { 
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"Last Name must have at least 2 characters!");
            }

            if (string.IsNullOrEmpty(request.CustomerTransport.LastName)) { 
                return new ValidationResult(ResponseStatusCode.InvalidRequest, $"Last Name is required!");
            }


            return null;
        }
    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, ServiceResponse<bool>>
    {

        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<bool>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request.CustomerTransport);

            await _context.Customer.AddAsync(customer);

            int result = await _context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<bool>
            {
                Data = result > 0 ? true : false
            };
        }
    }

}
