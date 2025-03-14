using HospitalManagement.BL.DTO.NurseWorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.EquipmentWorkDay
{
    public class EquipmentWorkDayDTO
    {
        public int EquipmentId { get; set; }
        public ICollection<EquipmentWorkDayDetailDTO> EquipmentWorkDays { get; set; }
    }

    public class EquipmentWorkDayDetailDTO
    {
        public string Day { get; set; }
        public ICollection<EquipmentWorkHourDTO> EquipmentWorkHours { get; set; }
    }
}
