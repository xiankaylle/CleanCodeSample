
using App.Core.Common.Models;
using App.Domain.Entities;
using Mapster;
/*
 https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0
 Install Microsoft.AspNetCore.Mvc.Core to use [ValidateNever]
 */
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; 

namespace App.Core.CustomerService.TransportModels
{
    public class CustomerTransport : BaseEntityTransport, IRegister
    {
        public int? Id { get; set; }
        [ValidateNever]
        public string FirstName { get; set; }
        [ValidateNever]
        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public string? MobileNumber { get; set; }
        public string? Email { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CustomerTransport, Customer>();

            config.NewConfig<Customer, CustomerTransport>();

        }
    }
}
