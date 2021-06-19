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
    public class SectionTypeSectionMap : IEntityTypeConfiguration<SectionTypeSection>
    {
        public void Configure(EntityTypeBuilder<SectionTypeSection> builder)
        {
            builder.ToTable("section_type_section");
            builder.HasKey(sts => new { sts.SectionId,sts.TypeSectionId});

            builder.Property(sts => sts.SectionId)
                .HasColumnName("section_id");

            builder.Property(sts => sts.TypeSectionId)
                .HasColumnName("type_section_id");

            builder.HasOne(sts => sts.Section)
                .WithMany(st => st.SectionTypeSections)
                .HasForeignKey(sts => sts.SectionId)
                .HasConstraintName("FK_section_id");

            builder.HasOne(sts => sts.TypeSection)
                .WithMany(ts => ts.SectionTypeSections)
                .HasForeignKey(sts => sts.TypeSectionId)
                .HasConstraintName("FK_type_section_id");

        }
    }
}
