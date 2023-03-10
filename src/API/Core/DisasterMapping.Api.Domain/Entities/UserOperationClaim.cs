using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class UserOperationClaim:BaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }

    }
}