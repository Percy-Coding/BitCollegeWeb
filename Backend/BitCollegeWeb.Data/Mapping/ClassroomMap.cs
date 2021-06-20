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
    public class ClassroomMap : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("classroom");
            builder.HasKey(c => c.ClassroomId);

            builder.Property(c => c.ClassroomId)
                .HasColumnName("classroom_id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.DateStart)
                .HasColumnName("date_start")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.SectionId)
                .HasColumnName("section_id");

            builder.Property(c => c.TeacherForumId)
                .HasColumnName("teacher_forum_id");

            builder.HasOne(c => c.Section)
                .WithMany(cs => cs.Classrooms)
                .HasForeignKey(c => c.SectionId);

        }
    }
}
