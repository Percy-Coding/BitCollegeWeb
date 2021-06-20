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
    public class URLMap : IEntityTypeConfiguration<URL>
    {
        public void Configure(EntityTypeBuilder<URL> builder)
        {
            builder.ToTable("url");
            builder.HasKey(u => u.UrlId);

            builder.Property(u => u.UrlId)
                .HasColumnName("url_id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UrlLink)
                .HasColumnName("url_link")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.ExternalToolId)
                .HasColumnName("external_tool_id");

            builder.Property(u => u.TopicId)
                .HasColumnName("topic_id");

            builder.HasOne(u => u.ExternalTool)
                .WithMany(ue => ue.URLS)
                .HasForeignKey(u => u.ExternalToolId);

            builder.HasOne(u => u.Topic)
                .WithMany(ut => ut.URLS)
                .HasForeignKey(u => u.TopicId);
        }
    }
}
