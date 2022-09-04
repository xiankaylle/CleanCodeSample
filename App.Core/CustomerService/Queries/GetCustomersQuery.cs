using App.Core.Common.ResponseWrapper;
using App.Core.Contracts;
using App.Core.CustomerService.TransportModels;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerService.Queries
{

    public class GetCustomersQuery : IRequest<ServiceResponse<List<CustomerTransport>>>
    {
    }

    public class GetCustomersQueryValidation : IValidationHandler<GetCustomersQuery>
    {
        public async Task<ValidationResult> Validate(GetCustomersQuery request)
        {
            return Task.FromResult<ValidationResult>(null).Result;
        }
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, ServiceResponse<List<CustomerTransport>>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CustomerTransport>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Customer.ToListAsync();
            
            var result = _mapper.Map<List<CustomerTransport>>(data);

            return new ServiceResponse<List<CustomerTransport>> {
                Data = result,

            };

        }
    }
}
