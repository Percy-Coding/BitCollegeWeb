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
    public class ProgrammingStudyMap : IEntityTypeConfiguration<ProgrammingStudy>
    {
        public void Configure(EntityTypeBuilder<ProgrammingStudy> builder)
        {
            builder.ToTable("programming_study");
            builder.HasKey(ps => ps.ProgrammingStudyId);

            builder.Property(ps => ps.ProgrammingStudyId)
                .HasColumnName("programming_study_id")
                .ValueGeneratedOnAdd();

            builder.Property(ps => ps.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(ps => ps.TypeStudyId)
                .HasColumnName("type_study_id");

            builder.Property(ps => ps.CalificationSystemId)
                .HasColumnName("calification_system_id");

            builder.Property(ps => ps.TypeProgrammingClassId)
                .HasColumnName("type_programming_class_id");

            builder.HasOne(ps => ps.TypeStudy)
                .WithMany(ts => ts.ProgrammingStudies)
                .HasForeignKey(ps => ps.TypeStudyId)
                .HasConstraintName("FK_type_study_id");

            builder.HasOne(ps => ps.CalificationSystem)
                .WithMany()
                .HasForeignKey(ps => ps.CalificationSystemId)
                .HasConstraintName("FK_calification_system_id");

            builder.HasOne(ps => ps.TypeProgrammingClass)
                .WithMany(tpc => tpc.ProgrammingStudies)
                .HasForeignKey(ps => ps.TypeProgrammingClassId)
                .HasConstraintName("FK_type_programming_class_id");

        }
    }
}
