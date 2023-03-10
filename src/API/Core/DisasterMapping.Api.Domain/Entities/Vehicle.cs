using DisasterMapping.Api.Domain.Entities.Common;
using DisasterMapping.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Domain.Entities
{
    public class Vehicle:BaseEntity
    {
        public VehicleType VehicleType { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
