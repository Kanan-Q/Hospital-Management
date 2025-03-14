using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class DiagnosticWorkDay
    {
        public int Id { get; set; }
        public int DiagnosticId { get; set; }
        public string Day { get; set; }
        public ICollection<DiagnosticWorkHour> DiagnosticWorkHours { get; set; }
        public Diagnostic Diagnostic { get; set; }
    }
}
