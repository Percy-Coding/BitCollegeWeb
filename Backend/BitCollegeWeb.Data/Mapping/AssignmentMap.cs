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
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {       
            builder.ToTable("assignment");
            //PK
            builder.HasKey(u => u.AssignmentId);
            builder.Property(u => u.AssignmentId)
                .HasColumnName("assignment_id")
                .ValueGeneratedOnAdd();

            //title
            builder.Property(u => u.Title)
                .HasColumnName("title")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            /*date_limit

            TODO TODO TODO TODO

            */
            //description
            builder.Property(u => u.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            /*section_id

            TODO TODO TODO TODO

            */

            /*document

            TODO TODO TODO TODO

            */

            /*shipping_date

            TODO TODO TODO TODO

            */

            //pending
            builder.Property(u => u.PendingComplete)
                 .HasColumnName("pending_complete")
                 .HasDefaultValueSql("((0))");

            //pending
            builder.Property(u => u.SentNotSent)
                  .HasColumnName("sent_notsent")
                  .HasDefaultValueSql("((0))");

            /*calification_assignment_id

            TODO TODO TODO TODO

            */

        }
    }
}
