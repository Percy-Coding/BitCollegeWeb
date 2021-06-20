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
    public class TypeProgrammingClassMap : IEntityTypeConfiguration<TypeProgrammingClass>
    {
        public void Configure(EntityTypeBuilder<TypeProgrammingClass> builder)
        {
            builder.ToTable("type_programming_class");
            builder.HasKey(tpc => tpc.TypeProgrammingClassId);

            builder.Property(tpc => tpc.TypeProgrammingClassId)
                .HasColumnName("type_programming_class_id")
                .ValueGeneratedOnAdd();

            builder.Property(tpc => tpc.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.HasOne(tpc => tpc.Schedule)
                .WithOne(sch => sch.TypeProgrammingClass)
                .HasForeignKey<Schedule>(sch => sch.TypeProgrammingClassId); 

        }
    }
}
