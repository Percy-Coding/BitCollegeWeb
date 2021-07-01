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
    public class TeacherSectionMap : IEntityTypeConfiguration<TeacherSection>
    {
        public void Configure(EntityTypeBuilder<TeacherSection> builder)
        {
            builder.ToTable("teacher_section");
            builder.HasKey(ts => new { ts.TeacherId, ts.SectionId });

            builder.Property(ts => ts.TeacherId)
                .HasColumnName("teacher_id");

            builder.Property(ts => ts.SectionId)
                .HasColumnName("section_id");

            builder.HasOne(ts => ts.Teacher)
                .WithMany(stu => stu.TeacherSections)
                .HasForeignKey(ts => ts.TeacherId);

            builder.HasOne(ts => ts.Section)
                .WithMany(s => s.TeacherSections)
                .HasForeignKey(ts => ts.SectionId);
        }
    }
}
