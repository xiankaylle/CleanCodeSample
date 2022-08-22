using App.Core.Common.Enums;
using App.Core.Common.ResponseWrapper;
using App.Core.Contracts;
using App.Core.CustomerService.TransportModels;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.CustomerService.Queries
{
    public class GetCustomerByIdQuery : IRequest<ServiceResponse<CustomerTransport>>
    {
        public int CustomerId { get; set; }
    }

    public class GetCustomerByIdQueryValidation : IValidationHandler<GetCustomerByIdQuery>
    {
        private readonly IAppDbContext _context;
        public GetCustomerByIdQueryValidation(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ValidationResult> Validate(GetCustomerByIdQuery request)
        {

            if (!(await _context.Customer.AnyAsync(x => x.Id == request.CustomerId)))
            {
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Customer does not exist!");
            }

            return Task.FromResult<ValidationResult>(null).Result;
        }

    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ServiceResponse<CustomerTransport>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CustomerTransport>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Customer.Where(p => p.Id == request.CustomerId).FirstOrDefaultAsync();

            var result = _mapper.Map<CustomerTransport>(data);

            return new ServiceResponse<CustomerTransport>()
            {
                Data = result
            };
        }
    }
}
