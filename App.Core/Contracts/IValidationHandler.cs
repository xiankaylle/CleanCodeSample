using App.Core.Common.ResponseWrapper;
namespace App.Core.Contracts
{
    public interface IValidationHandler
    {
    }
    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
