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
    public class EvidenceMap : IEntityTypeConfiguration<Evidence>
    {
        public void Configure(EntityTypeBuilder<Evidence> builder)
        {
            builder.ToTable("evidence");
            builder.HasKey(e => e.EvidenceId);

            builder.Property(e => e.EvidenceId)
                .HasColumnName("evidence_id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.EvidenceLink)
                .HasColumnName("evidence_link")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.TeacherForumId)
                .HasColumnName("teacher_forum_id");

            builder.HasOne(e => e.TeacherForum)
                .WithMany(etf => etf.Evidences)
                .HasForeignKey(e => e.TeacherForumId);
        }
    }
}
