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

            builder.HasOne(sch => sch.TypeProgrammingClass)
                .WithMany()
                .HasForeignKey(sch => sch.TypeProgrammingClassId)
                .HasConstraintName("FK_type_programming_class_id");

            builder.HasOne(sch => sch.Student)
                .WithMany(stu => stu.Schedules)
                .HasForeignKey(sch => sch.StudentId)
                .HasConstraintName("FK_student_id");
        }
    }
}
