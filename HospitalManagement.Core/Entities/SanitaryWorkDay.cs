using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class SanitaryWorkDay
    {
        public int Id { get; set; }
        public int SanitaryId { get; set; }
        public string Day { get; set; }
        public ICollection<SanitaryWorkHour> SanitaryWorkHours { get; set; }
        public Sanitary Sanitary { get; set; }
    }
}
