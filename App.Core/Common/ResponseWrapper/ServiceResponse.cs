
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
