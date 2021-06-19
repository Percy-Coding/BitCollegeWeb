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
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("topic");
            builder.HasKey(t => t.TopicId);

            builder.Property(t => t.TopicId)
                .HasColumnName("topic_id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
