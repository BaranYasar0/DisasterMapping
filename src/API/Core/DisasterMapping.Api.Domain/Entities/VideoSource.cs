using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class VideoSource:BaseEntity
    {
        public string VideoUrl { get; set; }
        public int DisasterId { get; set; }
        public Disaster Disaster { get; set; }

        public VideoSource(string videoUrl)
        {
            VideoUrl = videoUrl;
        }
    }
}