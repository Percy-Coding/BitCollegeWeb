using BitCollegeWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Data.Mapping
{
    public class CalificationSystemMap : IEntityTypeConfiguration<CalificationSystem>
    {
        public void Configure(EntityTypeBuilder<CalificationSystem> builder)
        {
            builder.ToTable("calification_system");
            //PK
            builder.HasKey(u => u.CalificationSystemId);
            builder.Property(u => u.CalificationSystemId)
                .HasColumnName("calification_systemt_id")
                .ValueGeneratedOnAdd();

            //number_percentage
            builder.Property(u => u.NumberPercentage)
                .HasColumnName("number_percentage")
                .IsRequired();
        }
    }
}
