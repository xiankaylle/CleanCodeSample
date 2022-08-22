using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.Enums
{
    public enum ResponseStatusCode
    {
        Ok,
        Created,
        InvalidEntity,
        EntityNotFound,
        InvalidRequest,
        ServerError,
        Forbidden
    }
}
