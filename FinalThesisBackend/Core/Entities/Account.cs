namespace FinalThesisBackend.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
