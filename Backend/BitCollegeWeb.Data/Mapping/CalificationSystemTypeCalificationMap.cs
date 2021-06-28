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
    public class CalificationSystemTypeCalificationMap : IEntityTypeConfiguration<CalificationSystemTypeCalification>
    {
        public void Configure(EntityTypeBuilder<CalificationSystemTypeCalification> builder)
        {
            builder.ToTable("calification_system_type_calification");
            builder.HasKey(cst => new { cst.CalificationSystemId, cst.TypeCalificationId});

            builder.Property(cst => cst.CalificationSystemId)
                .HasColumnName("calification_system_id");

            builder.Property(cst => cst.TypeCalificationId)
                .HasColumnName("type_calification_id");

            builder.HasOne(cst => cst.CalificationSystem)
                .WithMany(cs => cs.CalificationSystemTypeCalifications)
                .HasForeignKey(cst => cst.CalificationSystemId);

            builder.HasOne(cst => cst.TypeCalification)
                .WithMany(tc => tc.CalificationSystemTypeCalifications)
                .HasForeignKey(cst => cst.TypeCalificationId);
        }
    }
}
