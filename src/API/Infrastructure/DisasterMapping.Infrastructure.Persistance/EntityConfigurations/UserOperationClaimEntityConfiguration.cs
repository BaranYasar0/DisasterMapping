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
    public class UserOperationClaimEntityConfiguration:BaseEntityConfiguration<UserOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasOne(x => x.User)
                    .WithMany(x => x.UserOperationClaims)
                    .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.OperationClaim)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.OperationClaimId);

        }
    }
}
