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
    public class DayMap : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.ToTable("day");
            builder.HasKey(d => d.DayId);

            builder.Property(d => d.DayId)
                .HasColumnName("day_id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
