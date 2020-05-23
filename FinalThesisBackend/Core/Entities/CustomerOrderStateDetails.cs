using System;

namespace FinalThesisBackend.Core.Entities
{
    public class CustomerOrderStateDetails : BaseEntity
    {
        public override string Id { get => CustomerOrderId + EmployeeId + OrderState; }

        public string OrderState { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }

        public string CustomerOrderId { get; set; }
        public CustomerOrder CustomerOrder { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
