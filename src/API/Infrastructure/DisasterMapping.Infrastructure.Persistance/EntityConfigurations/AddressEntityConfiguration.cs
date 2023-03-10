using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Infrastructure.Persistance.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.EntityConfigurations
{
    public class AddressEntityConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.DisasterId)
                .HasColumnName("Disaster_Id");

            builder.HasOne(x => x.Disaster)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.DisasterId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(x => x.City);

            builder.HasMany(x => x.Vehicles);

        }
    }
}
