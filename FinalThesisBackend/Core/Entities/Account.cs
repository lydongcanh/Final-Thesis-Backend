using System;

namespace FinalThesisBackend.Core.Entities
{
    public class Account : BaseEntity
    {
        public enum Type
        {
            Admin,
            Customer,
            Employee
        };

        public string Username { get; set; }
        public string Password { get; set; }
        public Type AccountType { get; set; }
        public bool IsActive { get; set; }
    }
}
