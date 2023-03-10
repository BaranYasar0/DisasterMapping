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
    public class CityEntityConfiguration : BaseEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(x => x.Disasters)
                .WithOne(x => x.City)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Addresses);
        }
    }
}
