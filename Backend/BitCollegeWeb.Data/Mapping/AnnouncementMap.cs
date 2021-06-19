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
    public class AnnouncementMap : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("announcement");
            //PK
            builder.HasKey(a => a.AnnouncementId);
            builder.Property(a => a.AnnouncementId)
                .HasColumnName("announcement_id")
                .ValueGeneratedOnAdd();

            //title
            builder.Property(a => a.Title)
                .HasColumnName("title")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            //date_limit
            builder.Property(a => a.DateLimit)
                .HasColumnName("date_limit")
                .IsRequired();

            //description
            builder.Property(a => a.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            //section_id
            builder.Property(a => a.SectionId)
                .HasColumnName("section_id");

            //FK
            builder.HasOne(a => a.Section)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.SectionId)
                .HasConstraintName("FK_section_id");

        }
    }
}
