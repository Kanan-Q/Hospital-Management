using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.DataAccess.Configuration
{
    public class TherapistConfiguration:IEntityTypeConfiguration<Therapist>
    {
        public void Configure(EntityTypeBuilder<Therapist> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            builder.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Salary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.FIN).IsRequired(false).HasMaxLength(8).HasComment("Max 8 symbol");
            builder.Property(x => x.Series).IsRequired(false).HasMaxLength(9).HasComment("Max 9 symbol");
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(50).HasComment("Max 50 symbols can use");
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Therapists).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
