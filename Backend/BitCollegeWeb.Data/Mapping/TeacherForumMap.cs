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
    public class TeacherForumMap : IEntityTypeConfiguration<TeacherForum>
    {
        public void Configure(EntityTypeBuilder<TeacherForum> builder)
        {
            builder.ToTable("teacher_forum");
            builder.HasKey(tf => tf.TeacherForumId);

            builder.Property(tf => tf.TeacherForumId)
                .HasColumnName("teacher_forum_id")
                .ValueGeneratedOnAdd();
            
            builder.Property(tf => tf.ProblemDescription)
                .HasColumnName("problem_description")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(tf => tf.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.HasOne(tf => tf.Classroom)
                .WithOne(cl => cl.TeacherForum)
                .HasForeignKey<Classroom>(cl => cl.TeacherForumId);

        }
    }
}
