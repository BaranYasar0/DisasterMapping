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
    public class VehicleEntityConfiguration:BaseEntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(x => x.Address)
                    .WithMany(x => x.Vehicles)
                    .HasForeignKey(x => x.AddressId);
        }
    }
}
