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
    public class ChatMap : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("chat");
            builder.HasKey(c => c.ChatId);

            builder.Property(c => c.ChatId)
                .HasColumnName("chat_id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Content)
                .HasColumnName("content")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.ClassroomId)
                .HasColumnName("classroom_id");

            builder.Property(c => c.TeacherId)
                .HasColumnName("teacher_id");

            builder.HasOne(c => c.Classroom)
                .WithMany(cl => cl.Chats)
                .HasForeignKey(c => c.ClassroomId);

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Chats)
                .HasForeignKey(c => c.TeacherId);
        }
    }
}
