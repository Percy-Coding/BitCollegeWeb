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
    public class TeacherExperienceMap : IEntityTypeConfiguration<TeacherExperience>
    {
        public void Configure(EntityTypeBuilder<TeacherExperience> builder)
        {
            builder.ToTable("teacher_experience");
            builder.HasKey(te => te.TeacherExperienceId);

            builder.Property(te => te.TeacherExperienceId)
                .HasColumnName("teacher_experience_id")
                .ValueGeneratedOnAdd();

            builder.Property(te => te.DateStartProgramming)
                .HasColumnName("date_start_programming")
                .IsRequired();

            builder.Property(te => te.Position)
                .HasColumnName("position")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(te => te.CompanyId)
                .HasColumnName("company_id");

            builder.HasOne(te => te.Company)
                .WithMany(co => co.TeacherExperiences)
                .HasForeignKey(te => te.CompanyId);

            builder.HasOne(te => te.Teacher)
                .WithOne(t => t.TeacherExperience)
                .HasForeignKey<Teacher>(t => t.TeacherExperienceId);

        }
    }
}
