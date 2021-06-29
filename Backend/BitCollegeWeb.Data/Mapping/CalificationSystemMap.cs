﻿using BitCollegeWeb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Infrastructure.Mapping
{
    public class CalificationSystemMap : IEntityTypeConfiguration<CalificationSystem>
    {
        public void Configure(EntityTypeBuilder<CalificationSystem> builder)
        {
            builder.ToTable("calification_system");
            //PK
            builder.HasKey(cs => cs.CalificationSystemId);
            builder.Property(cs => cs.CalificationSystemId)
                .HasColumnName("calification_system_id")
                .ValueGeneratedOnAdd();

            //calification_system_code
            builder.Property(cs => cs.CalificationSystemCode)
                .HasColumnName("calification_system_code")
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsRequired();

            //relation 1 to 1  to ProgrammingStudy
            builder.HasOne(cs => cs.ProgrammingStudy)
                .WithOne(ps => ps.CalificationSystem)
                .HasForeignKey<ProgrammingStudy>(ps => ps.CalificationSystemId);
        }
    }
}
