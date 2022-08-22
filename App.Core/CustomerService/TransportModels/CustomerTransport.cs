
using App.Domain.Entities;
using Mapster;
using System.ComponentModel.DataAnnotations;

namespace App.Core.CustomerService.TransportModels
{
    public class CustomerTransport : IRegister
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

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
