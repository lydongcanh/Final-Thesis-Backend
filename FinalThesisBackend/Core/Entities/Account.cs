namespace FinalThesisBackend.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string AccountType { get; set; }
    }
}
