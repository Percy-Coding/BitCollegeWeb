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
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {       
            builder.ToTable("assignment");
            //PK
            builder.HasKey(ag => ag.AssignmentId);
            builder.Property(ag => ag.AssignmentId)
                .HasColumnName("assignment_id")
                .ValueGeneratedOnAdd();

            //title
            builder.Property(ag => ag.Title)
                .HasColumnName("title")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            //date_limit
            builder.Property(ag => ag.DateLimit)
                .HasColumnName("date_limit")
                .IsRequired();

            //description
            builder.Property(ag => ag.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            //section_id
            builder.Property(ag => ag.SectionId)
                .HasColumnName("section_id");

            //document
            builder.Property(ag => ag.DocumentLink)
                .HasColumnName("document_link")
                .HasMaxLength(500)
                .IsUnicode(false);

            //shipping_date
            builder.Property(ag => ag.ShippingDate)
                .HasColumnName("shipping_date");

            //pending
            builder.Property(ag => ag.PendingComplete)
                 .HasColumnName("pending_complete")
                 .HasDefaultValueSql("((0))");

            //sent
            builder.Property(ag => ag.SentNotSent)
                  .HasColumnName("sent_notsent")
                  .HasDefaultValueSql("((0))");

            //calification_assignment_id
            builder.Property(ag => ag.CalificationAssignmentId)
                  .HasColumnName("calification_assignment_id");

            //FK
            builder.HasOne(ag => ag.Section)
                .WithMany(ags => ags.Assignments)
                .HasForeignKey(ag => ag.SectionId);

            builder.HasOne(ag => ag.CalificationAssignment)
                .WithMany(ags => ags.Assignments)
                .HasForeignKey(ag => ag.CalificationAssignmentId);

        }
    }
}
