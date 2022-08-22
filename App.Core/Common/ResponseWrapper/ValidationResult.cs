using App.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.ResponseWrapper
{
    public class ValidationResult
    {
        public ValidationResult(ResponseStatusCode responseStatusCode, params string[] errors)
        {
            ResponseStatusCode = responseStatusCode;
            Errors = errors;
        }
        public ResponseStatusCode ResponseStatusCode { get; }
        public string[] Errors { get; }
    }
}
