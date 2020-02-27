using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FinalThesisBackend.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string ImagePath { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
    }
}
