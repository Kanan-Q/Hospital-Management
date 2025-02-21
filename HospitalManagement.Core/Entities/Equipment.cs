﻿using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Equipment:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public decimal? Salary { get; set; }
        public string Email { get; set; }
        public string FIN { get; set; }
        public string Series { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
