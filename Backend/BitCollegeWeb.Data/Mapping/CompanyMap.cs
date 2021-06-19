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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");
            builder.HasKey(com => com.CompanyId);

            builder.Property(com => com.CompanyId)
                .HasColumnName("company_id")
                .ValueGeneratedOnAdd();

            builder.Property(com => com.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(com => com.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
