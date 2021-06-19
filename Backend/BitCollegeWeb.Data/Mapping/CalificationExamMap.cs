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
    public class CalificationExamMap : IEntityTypeConfiguration<CalificationExam>
    {
        public void Configure(EntityTypeBuilder<CalificationExam> builder)
        {
            builder.ToTable("calification_exam");
            //PK
            builder.HasKey(ce => ce.CalificationExamId);
            builder.Property(ce => ce.CalificationExamId)
                .HasColumnName("calification_exam_id")
                .ValueGeneratedOnAdd();

            //note
            builder.Property(ce => ce.Note)
                .HasColumnName("note")
                .IsRequired();
        }
    }
}
