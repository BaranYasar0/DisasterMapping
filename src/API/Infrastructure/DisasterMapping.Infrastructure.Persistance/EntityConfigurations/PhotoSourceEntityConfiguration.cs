using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Infrastructure.Persistance.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.EntityConfigurations
{
    public class PhotoSourceEntityConfiguration:BaseEntityConfiguration<PhotoSource>
    {
        public override void Configure(EntityTypeBuilder<PhotoSource> builder)
        {
            builder.HasOne(x => x.Disaster)
                    .WithMany(x => x.PhotoSources)
                    .HasForeignKey(x => x.DisasterId);

            builder.Property(x => x.PhotoUrl)
                .HasColumnName("PhotoUrl");
        }
    }
}
