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
    public class StudentSectionMap : IEntityTypeConfiguration<StudentSection>
    {
        public void Configure(EntityTypeBuilder<StudentSection> builder)
        {
            builder.ToTable("student_section");
            builder.HasKey(ss => new { ss.StudentId, ss.SectionId });

            builder.Property(ss => ss.StudentId)
                .HasColumnName("student_id");

            builder.Property(ss => ss.SectionId)
                .HasColumnName("section_id");

            builder.HasOne(ss => ss.Student)
                .WithMany(stu => stu.StudentSections)
                .HasForeignKey(ss => ss.StudentId);

            builder.HasOne(ss => ss.Section)
                .WithMany(s => s.StudentSections)
                .HasForeignKey(ss => ss.SectionId);
        }
    }
}
