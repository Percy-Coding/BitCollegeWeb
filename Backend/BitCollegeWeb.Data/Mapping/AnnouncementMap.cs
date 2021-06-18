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
            builder.HasKey(u => u.AnnouncementId);
            builder.Property(u => u.AnnouncementId)
                .HasColumnName("announcement_id")
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
        }
    }
}
