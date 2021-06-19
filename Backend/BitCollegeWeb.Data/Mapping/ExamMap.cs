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
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("exam");
            builder.HasKey(e => e.ExamId);

            builder.Property(e => e.ExamId)
                .HasColumnName("exam_id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.DateStart)
                .HasColumnName("date_start")
                .IsRequired();

            builder.Property(e => e.StartTime)
                .HasColumnName("start_time")
                .IsRequired();

            builder.Property(e => e.FinishTime)
                .HasColumnName("finish_time")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.SectionId)
                .HasColumnName("section_id");

            builder.Property(e => e.CalificationExamId)
                .HasColumnName("calification_exam_id");

            builder.Property(e => e.PendingComplete)
                .HasColumnName("pending_complete")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.SentNotSent)
                   .HasColumnName("sent_notsent")
                   .HasDefaultValueSql("((0))");

            builder.HasOne(e => e.CalificationExam)
                .WithMany(ce => ce.Exams)
                .HasForeignKey(e => e.CalificationExamId)
                .HasConstraintName("FK_calification_exam_id");

            builder.HasOne(e => e.Section)
                .WithMany(es => es.Exams)
                .HasForeignKey(e => e.SectionId)
                .HasConstraintName("FK_section_id");

        }
    }
}
