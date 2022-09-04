using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface IServicePagingRequest
    {
        int CurrentPage { get; set; }
        int ItemsPerPage { get; set; }
    }
}
