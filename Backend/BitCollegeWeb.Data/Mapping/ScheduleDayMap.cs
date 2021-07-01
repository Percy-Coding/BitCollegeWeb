using BitCollegeWeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Infrastructure.Mapping
{
    public class ScheduleDayMap : IEntityTypeConfiguration<ScheduleDay>
    {
        public void Configure(EntityTypeBuilder<ScheduleDay> builder)
        {
            builder.ToTable("schedule_day");
            builder.HasKey(sd => new { sd.ScheduleId, sd.DayId });

            builder.Property(sd => sd.ScheduleId)
                .HasColumnName("schedule_id")
                .IsRequired();

            builder.Property(sd => sd.DayId)
                .HasColumnName("day_id")
                .IsRequired();

            builder.Property(sd => sd.StartTime)
                .HasColumnName("start_time")
                .IsRequired();

            builder.Property(sd => sd.FinishTime)
                .HasColumnName("finish_time")
                .IsRequired();

            builder.HasOne(sd => sd.Schedule)
                .WithMany(sch => sch.ScheduleDays)
                .HasForeignKey(sd => sd.ScheduleId);

            builder.HasOne(sd => sd.Day)
                .WithMany(d => d.ScheduleDays)
                .HasForeignKey(sd => sd.DayId);
        }
    }
}
