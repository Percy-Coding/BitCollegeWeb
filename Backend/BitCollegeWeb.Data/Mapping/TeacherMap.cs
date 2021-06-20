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
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("teacher");
            builder.HasKey(t => t.TeacherId);

            builder.Property(t => t.TeacherId)
                .HasColumnName("teacher_id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TeacherExperienceId)
                .HasColumnName("teacher_experience_id");

        }
    }
}
