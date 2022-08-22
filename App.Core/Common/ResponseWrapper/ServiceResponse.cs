using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.ResponseWrapper
{
    public class ServiceResponse<T> : RequestResponse
    {
        /// <summary>
        /// Response Data
        /// </summary>
        public T Data { get; set; }
    }
}
