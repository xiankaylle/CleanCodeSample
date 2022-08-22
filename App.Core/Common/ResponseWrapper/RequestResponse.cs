using App.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Core.Common.ResponseWrapper
{
    public class RequestResponse
    {
        [JsonIgnore]
        public ResponseStatusCode ResponseStatusCode { get; set; } = ResponseStatusCode.Ok;
        [JsonIgnore]
        public bool IsSuccess { get { return ResponseStatusCode == ResponseStatusCode.Ok || ResponseStatusCode == ResponseStatusCode.Created; } }
        public string[] ErrorMessages { get; set; }

    }
}
