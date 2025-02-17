using HospitalManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Configuration
{
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.HasKey(x => new { x.DoctorId, x.PatientId });
            builder.HasOne(x => x.Doctor).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Patient).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Cascade);

        }
    }

}
