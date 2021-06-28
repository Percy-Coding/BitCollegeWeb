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
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("schedule");
            builder.HasKey(sch => sch.ScheduleId);

            builder.Property(sch => sch.ScheduleId)
                .HasColumnName("schedule_id")
                .ValueGeneratedOnAdd();

            builder.Property(sch => sch.TypeProgrammingClassId)
                .HasColumnName("type_programming_class_id")
                .IsRequired();

            builder.Property(sch => sch.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            builder.HasOne(sch => sch.Student)
                .WithMany(stu => stu.Schedules)
                .HasForeignKey(sch => sch.StudentId);
        }
    }
}
