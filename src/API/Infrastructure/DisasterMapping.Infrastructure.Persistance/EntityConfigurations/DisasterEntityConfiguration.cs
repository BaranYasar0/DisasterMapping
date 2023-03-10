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
    public class DisasterEntityConfiguration:BaseEntityConfiguration<Disaster>
    {
        public override void Configure(EntityTypeBuilder<Disaster> builder)
        {
            builder.HasOne(x => x.Address)
                    .WithOne(x => x.Disaster)
                    .HasForeignKey<Disaster>(x => x.AddressId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.City)
                    .WithMany(x => x.Disasters)
                    .HasForeignKey(x => x.CityId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
