using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Configuration
{
    public class PrecriptionConfiguration:IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => new { x.DoctorId, x.PatientId });
            builder.HasOne(x => x.Doctor).WithMany(x => x.Prescriptions).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Patient).WithMany(x => x.Prescriptions).HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
