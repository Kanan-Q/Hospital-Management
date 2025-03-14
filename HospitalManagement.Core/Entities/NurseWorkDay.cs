using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class NurseWorkDay
    {
        public int Id { get; set; }
        public int NurseId { get; set; }
        public string Day { get; set; }
        public ICollection<NurseWorkHour> NurseWorkHours { get; set; }
        public Nurse Nurse { get; set; }
    }
}
