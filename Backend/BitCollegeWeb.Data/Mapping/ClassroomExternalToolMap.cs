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
    public class ClassroomExternalToolMap : IEntityTypeConfiguration<ClassroomExternalTool>
    {
        public void Configure(EntityTypeBuilder<ClassroomExternalTool> builder)
        {
            builder.ToTable("classroom_external_tool");
            builder.HasKey(cet => new { cet.ExternalToolId, cet.ClassroomId});

            builder.Property(cet => cet.ExternalToolId)
                .HasColumnName("external_tool_id");

            builder.Property(cet => cet.ClassroomId)
                .HasColumnName("classroom_id");

            builder.HasOne(cet => cet.ExternalTool)
                .WithMany(et => et.ClassroomExternalTools)
                .HasForeignKey(cet => cet.ExternalToolId);

            builder.HasOne(cet => cet.Classroom)
                .WithMany(c => c.ClassroomExternalTools)
                .HasForeignKey(cet => cet.ClassroomId);
        }
    }
}
