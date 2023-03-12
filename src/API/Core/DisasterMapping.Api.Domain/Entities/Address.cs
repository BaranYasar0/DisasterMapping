using DisasterMapping.Api.Domain.Entities.Common;

namespace DisasterMapping.Api.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string FullAddress { get; set; }
        public string? Distinct { get; set; }
        public string? Street { get; set; }
        //public int? DisasterId { get; set; }
        public Disaster? Disaster { get; set; }
        public City? City { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }


        public Address()
        {
            
        }

        public Address(string fullAddress, string? distinct = null, string? street = null) : this()
        {
            FullAddress = fullAddress;
            Distinct = distinct;
            Street = street;
            //DisasterId = disasterId;
        }
    }
}