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
    public class CalificationAssignmentMap : IEntityTypeConfiguration<CalificationAssignment>
    {
        public void Configure(EntityTypeBuilder<CalificationAssignment> builder)
        {
            builder.ToTable("calification_assignment");
            //PK
            builder.HasKey(u => u.CalificationAssignmentId);
            builder.Property(u => u.CalificationAssignmentId)
                .HasColumnName("calification_assignment_id")
                .ValueGeneratedOnAdd();

            //note
            builder.Property(u => u.Note)
                .HasColumnName("note")
                .IsRequired();

            //commend
            builder.Property(u => u.Comment)
                 .HasColumnName("comment")
                 .HasMaxLength(500)
                 .IsUnicode(false)
                 .IsRequired();

            //comment_published
            builder.Property(u => u.CommentPublished)
                  .HasColumnName("comment_published")
                  .HasDefaultValueSql("((0))");
        }
    }
}
