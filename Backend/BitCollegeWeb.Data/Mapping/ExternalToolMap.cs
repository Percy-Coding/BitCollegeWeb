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
    public class ExternalToolMap : IEntityTypeConfiguration<ExternalTool>
    {
        public void Configure(EntityTypeBuilder<ExternalTool> builder)
        {
            builder.ToTable("external_tool");
            builder.HasKey(et => et.ExternalToolId);

            builder.Property(et => et.ExternalToolId)
                .HasColumnName("external_tool_id")
                .ValueGeneratedOnAdd();

            builder.Property(et => et.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(et => et.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}
