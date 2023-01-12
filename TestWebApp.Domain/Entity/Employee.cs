using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeePositionId { get; set; }

        public virtual User EmployeeNavigation { get; set; }
        public virtual EmployeePosition EmployeePosition { get; set; }
    }
}
