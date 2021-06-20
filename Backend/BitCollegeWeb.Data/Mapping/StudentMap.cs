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
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student");
            builder.HasKey(st => st.StudentId);

            builder.Property(st => st.StudentId)
                .HasColumnName("student_id")
                .ValueGeneratedOnAdd();

            builder.Property(st => st.StudentExperienceId)
                .HasColumnName("student_experience_id");
        }
    }
}
