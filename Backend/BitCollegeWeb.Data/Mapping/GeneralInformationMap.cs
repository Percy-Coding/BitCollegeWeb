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
    public class GeneralInformationMap : IEntityTypeConfiguration<GeneralInformation>
    {
        public void Configure(EntityTypeBuilder<GeneralInformation> builder)
        {
            builder.ToTable("general_information");
            builder.HasKey(gi => new { gi.TopicId, gi.ProgrammingStudyId });

            builder.Property(gi => gi.TopicId)
                .HasColumnName("topic_id");

            builder.Property(gi => gi.ProgrammingStudyId)
                .HasColumnName("programming_study_id");

            builder.HasOne(gi => gi.Topic)
                .WithMany(t => t.GeneralInformations)
                .HasForeignKey(gi => gi.TopicId);

            builder.HasOne(gi => gi.ProgrammingStudy)
                .WithMany(ps => ps.GeneralInformations)
                .HasForeignKey(gi => gi.ProgrammingStudyId);
        }
    }
}
