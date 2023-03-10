using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class SoundSource:BaseEntity
    {
        public string PhotoUrl { get; set; }
        public int DisasterId { get; set; }
        public Disaster Disaster { get; set; }

        public SoundSource(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }
    }
}