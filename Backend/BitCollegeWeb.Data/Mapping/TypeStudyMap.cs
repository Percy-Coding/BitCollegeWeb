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
    public class TypeStudyMap : IEntityTypeConfiguration<TypeStudy>
    {
        public void Configure(EntityTypeBuilder<TypeStudy> builder)
        {
            builder.ToTable("type_study");
            builder.HasKey(ts => ts.TypeStudyId);

            builder.Property(ts => ts.TypeStudyId)
                .HasColumnName("type_study_id")
                .ValueGeneratedOnAdd();

            builder.Property(ts => ts.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(ts => ts.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
