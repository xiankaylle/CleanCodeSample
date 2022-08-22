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
                Data = result > 0 ? true : false,
                ResponseStatusCode = ResponseStatusCode.Ok
            };
        }
    }

}
