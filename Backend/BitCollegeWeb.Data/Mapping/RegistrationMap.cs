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
    public class RegistrationMap : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("registration");
            builder.HasKey(r => r.RegistrationId);

            builder.Property(r => r.RegistrationId)
                .HasColumnName("registration_id")
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(r => r.Email)
                .HasColumnName("email")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(r => r.Password)
                .HasColumnName("password")
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(r => r.StudentId)
                .HasColumnName("student_id");

            builder.Property(r => r.TeacherId)
                .HasColumnName("teacher_id");

            builder.HasOne(r => r.Student)
                .WithMany(st => st.Registrations)
                .HasForeignKey(r => r.StudentId)
                .HasConstraintName("FK_student_id");

            builder.HasOne(r => r.Teacher)
                .WithMany(t => t.Registrations)
                .HasForeignKey(r => r.TeacherId)
                .HasConstraintName("FK_teacher_id");
        }
    }
}
