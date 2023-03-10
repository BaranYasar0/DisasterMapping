using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class PhotoSource : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public int DisasterId { get; set; }
        public Disaster Disaster { get; set; }

        public PhotoSource(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }
    }
}