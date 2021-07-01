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
    public class TypeSectionMap : IEntityTypeConfiguration<TypeSection>
    {
        public void Configure(EntityTypeBuilder<TypeSection> builder)
        {
            builder.ToTable("type_section");
            builder.HasKey(ts => ts.TypeSectionId);

            builder.Property(ts => ts.TypeSectionId)
                .HasColumnName("type_section_id")
                .ValueGeneratedOnAdd();

            builder.Property(ts => ts.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}
