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
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notification");
            builder.HasKey(n => n.NotificationId);

            builder.Property(n => n.NotificationId)
                .HasColumnName("notification_id")
                .ValueGeneratedOnAdd();

            builder.Property(n => n.Title)
                .HasColumnName("title")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(n => n.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(n => n.StudentId)
                .HasColumnName("student_id");

            builder.Property(n => n.TeacherId)
                .HasColumnName("teacher_id");

            builder.Property(n => n.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.HasOne(n => n.Student)
                .WithMany(st => st.Notifications)
                .HasForeignKey(n => n.StudentId)
                .HasConstraintName("FK_student_id");

            builder.HasOne(n => n.Teacher)
                .WithMany(t => t.Notifications)
                .HasForeignKey(n => n.TeacherId)
                .HasConstraintName("FK_teacher_id");
        }
    }
}
