using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class OperationClaim:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public OperationClaim()
        {

        }

        public OperationClaim(string name):this()
        {
            Name = name;
        }
    }
}