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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            //builder.HasIndex(x => x.Id).IsUnique();
            //builder.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //builder.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //builder.Property(x => x.Age).IsRequired().HasDefaultValue(0);
            //builder.Property(x => x.Salary).IsRequired().HasColumnType("decimal(18,2)");
            //builder.Property(x => x.FIN).IsRequired(false).HasMaxLength(8).HasComment("Max 8 symbol");
            //builder.Property(x => x.Series).IsRequired(false).HasMaxLength(9).HasComment("Max 9 symbol");
            //builder.Property(x => x.Address).IsRequired(false).HasMaxLength(50).HasComment("Max 50 symbols can use");
            builder.Property(x => x.DepartmentId);
            builder.HasOne(x => x.Department).WithMany(x => x.Doctors).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
