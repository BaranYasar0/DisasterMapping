using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Infrastructure.Persistance.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.EntityConfigurations
{
    public class VideoSourceEntityConfiguration:BaseEntityConfiguration<VideoSource>
    {
        public override void Configure(EntityTypeBuilder<VideoSource> builder)
        {
            builder.HasOne(x => x.Disaster)
                    .WithMany(x => x.VideoSources)
                    .HasForeignKey(x => x.DisasterId);
        }
    }
}
