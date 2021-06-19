﻿using BitCollegeWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCollegeWeb.Data.Mapping
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

            //number_percentage
            builder.Property(cs => cs.NumberPercentage)
                .HasColumnName("number_percentage")
                .IsRequired();
        }
    }
}
