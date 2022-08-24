using App.Core.Common.ResponseWrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface IServiceRequest<T> : IRequest<ServiceResponse<T>>
    {
    }
}
