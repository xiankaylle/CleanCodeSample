using App.Core.Common.Enums;


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
