using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class NurseWorkHour
    {
        public int Id { get; set; }
        public int NurseWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public NurseWorkDay NurseWorkDay { get; set; }
    }
}
