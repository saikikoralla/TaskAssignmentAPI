using System;
using System.Collections.Generic;

namespace TaskAssignmentSystem.Model2
{
    public partial class Employee
    {
        public Employee()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
