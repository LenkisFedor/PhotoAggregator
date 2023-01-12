using System;
using System.Collections.Generic;

#nullable disable

namespace TestWebApp.Domain.Entity
{
    public partial class EmployeePosition
    {
        public EmployeePosition()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
