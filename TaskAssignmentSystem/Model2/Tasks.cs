using System;
using System.Collections.Generic;

namespace TaskAssignmentSystem.Model2
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int EmployeeId { get; set; }
        public string DescriptionName { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
