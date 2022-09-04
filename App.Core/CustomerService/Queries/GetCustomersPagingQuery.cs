using App.Core.Common.RequestsWrapper;
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
    public class GetCustomersPagingQuery : ServicePagingRequest<IEnumerable<CustomerTransport>>
    {
    }
    public class GetCustomersPagingQueryValidation : IValidationHandler<GetCustomersPagingQuery>
    {
        public async Task<ValidationResult> Validate(GetCustomersPagingQuery request)
        {
            return Task.FromResult<ValidationResult>(null).Result;
        }
    }

    public class GetCustomersPagingQueryHandler : IRequestHandler<GetCustomersPagingQuery, ServiceResponse<IEnumerable<CustomerTransport>>>
    {
      
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersPagingQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<CustomerTransport>>> Handle(GetCustomersPagingQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Customer;          

            var totalItems = await query.CountAsync();

            var items = await query.OrderBy(c => c.Id.Value).Skip(request.SkipItems).Take(request.ItemsPerPage).ToListAsync();

            var result = _mapper.Map<List<CustomerTransport>>(items);

            return new ServicePagingResponse<CustomerTransport>()
            {
                 Data = result,
                 TotalItems = totalItems,
                 CurrentPage = request.CurrentPage,
                 ItemsPerPage = request.ItemsPerPage,
            };

        }
    }
}
