namespace App.Domain.Entities
{
    public class Customer : BaseEntity
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

    }
}