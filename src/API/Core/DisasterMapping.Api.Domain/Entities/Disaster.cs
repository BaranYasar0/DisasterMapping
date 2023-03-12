using DisasterMapping.Api.Domain.Entities.Common;
using DisasterMapping.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Domain.Entities
{
    public class Disaster : BaseEntity
    {
        public DisasterType DisasterType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Location { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public ICollection<PhotoSource>? PhotoSources { get; set; }
        public ICollection<VideoSource>? VideoSources { get; set; }
        public ICollection<SoundSource>? SoundSources { get; set; }
        //public int? UserId { get; set; }
        //public User? User { get; set; }

        public Disaster()
        {
            Address = new Address();
        }

        public Disaster(DisasterType disasterType, string name, string description, string location,int addressId,int? cityId=null)
        {
            DisasterType = disasterType;
            Name = name;
            Description = description;
            Location = location;
            AddressId = addressId;
            CityId = cityId;
        }

    }
}
