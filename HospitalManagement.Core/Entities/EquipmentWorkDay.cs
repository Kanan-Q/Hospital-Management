using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class EquipmentWorkDay
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string Day { get; set; }
        public ICollection<EquipmentWorkHour> EquipmentWorkHours { get; set; }
        public Equipment Equipment { get; set; }
    }
}
