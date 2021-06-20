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
    public class StudentExperienceMap : IEntityTypeConfiguration<StudentExperience>
    {
        public void Configure(EntityTypeBuilder<StudentExperience> builder)
        {
            builder.ToTable("student_experience");
            builder.HasKey(se => se.StudentExperienceId);

            builder.Property(se => se.StudentExperienceId)
                .HasColumnName("student_experience_id")
                .ValueGeneratedOnAdd();

            builder.Property(se => se.DateStartProgramming)
                .HasColumnName("date_start_programming")
                .IsRequired();

            builder.Property(se => se.InstitutionId)
                .HasColumnName("institution_id");

            builder.HasOne(se => se.Institution)
                .WithMany(i => i.StudentExperiences)
                .HasForeignKey(se => se.InstitutionId);

            builder.HasOne(se => se.Student)
                .WithOne(st => st.StudentExperience)
                .HasForeignKey<Student>(st => st.StudentExperienceId);

        }
    }
}
