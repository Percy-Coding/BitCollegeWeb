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
    public class SectionMap : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("section");
            builder.HasKey(s => s.SectionId);

            builder.Property(s => s.SectionId)
                .HasColumnName("section_id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.SectionCode)
                .HasColumnName("section_code")
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(s => s.ProgrammingStudyId)
                .HasColumnName("programming_study_id")
                .IsRequired();

            builder.Property(s => s.NumberRecordings)
                .HasColumnName("number_recordings");

            builder.Property(s => s.NumberStudentsEnroll)
                .HasColumnName("number_students_enroll");

            builder.Property(s => s.Vacancies)
                .HasColumnName("vacancies")
                .HasDefaultValueSql("((1))");

        }
    }
}
