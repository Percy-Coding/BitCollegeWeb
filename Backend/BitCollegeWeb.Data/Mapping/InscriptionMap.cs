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
    public class InscriptionMap : IEntityTypeConfiguration<Inscription>
    {
        public void Configure(EntityTypeBuilder<Inscription> builder)
        {
            builder.ToTable("inscription");
            builder.HasKey(i => i.InscriptionId);

            builder.Property(i => i.InscriptionId)
                .HasColumnName("inscription_id")
                .ValueGeneratedOnAdd();

            builder.Property(i => i.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            builder.Property(i => i.ProgrammingStudyId)
                .HasColumnName("programming_study_id")
                .IsRequired();

            builder.Property(i => i.DateInscription)
               .HasColumnName("date_inscription")
               .IsRequired();

            builder.HasOne(i => i.Student)
                .WithMany(st => st.Inscriptions)
                .HasForeignKey(i => i.StudentId)
                .HasConstraintName("FK_student_id");

            builder.HasOne(i => i.ProgrammingStudy)
                .WithMany(ps => ps.Inscriptions)
                .HasForeignKey(i => i.ProgrammingStudyId)
                .HasConstraintName("FK_programming_study_id");
        }
    }
}
