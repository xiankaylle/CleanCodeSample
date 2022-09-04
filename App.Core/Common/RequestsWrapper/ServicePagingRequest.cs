using App.Core.Contracts;
using System.Runtime.Serialization;

namespace App.Core.Common.RequestsWrapper
{
    public class ServicePagingRequest<T> : IServiceRequest<T>, IServicePagingRequest
    {
        public int CurrentPage { get; set; }
        [IgnoreDataMember]
        public int SkipItems { get => CurrentPage <= 1 ? 0 : (CurrentPage - 1) * ItemsPerPage; }
        public int ItemsPerPage { get; set; }
    }
}
