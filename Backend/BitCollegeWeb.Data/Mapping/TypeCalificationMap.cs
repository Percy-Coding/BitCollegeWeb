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
    public class TypeCalificationMap : IEntityTypeConfiguration<TypeCalification>
    {
        public void Configure(EntityTypeBuilder<TypeCalification> builder)
        {
            builder.ToTable("type_calification");
            builder.HasKey(tc => tc.TypeCalificationId);

            builder.Property(tc => tc.TypeCalificationId)
                .HasColumnName("type_calification_id")
                .ValueGeneratedOnAdd();

            builder.Property(tc => tc.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
