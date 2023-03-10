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
    public class OperationClaimEntityConfiguration : BaseEntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasMany(x => x.UserOperationClaims);
        }
    }
}
