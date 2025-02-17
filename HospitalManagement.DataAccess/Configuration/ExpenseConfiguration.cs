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
    public class ExpenseConfiguration:IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder) 
        {
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            builder.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            builder.Property(x => x.Expenses).IsRequired(false);
            builder.Property(x => x.Phone).IsRequired(false);
            builder.Property(x => x.Source).IsRequired(false);
        }
    }
}
