using DisasterMapping.Api.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Domain.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public string? District { get; set; }
        public ICollection<Disaster>? Disasters { get; set; }
        public ICollection<Address>? Addresses { get; set; }

        public City()
        {

        }
        public City(string name, string? district=null):this()
        {
            Name = name;
            District = district;
        }
    }
}
