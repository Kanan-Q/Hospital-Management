﻿using HospitalManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities.Common
{
    public class Diagnostic:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public decimal? Salary { get; set; }
        public string Email { get; set; }
        public string FIN { get; set; }
        public string Series { get; set; }
        public DateOnly Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<DiagnosticWorkDay> DiagnosticWorkDays { get; set; }
    }
}
