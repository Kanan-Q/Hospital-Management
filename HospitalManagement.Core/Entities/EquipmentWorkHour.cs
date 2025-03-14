using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class EquipmentWorkHour
    {
        public int Id { get; set; }
        public int EquipmentWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public EquipmentWorkDay EquipmentWorkDay { get; set; }
    }
}
