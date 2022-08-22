using App.Core.Common.ResponseWrapper;
namespace App.Core.Contracts
{
    /// <summary>
    /// Marker for DI
    /// </summary>
    public interface IValidationHandler
    {
    }
    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
