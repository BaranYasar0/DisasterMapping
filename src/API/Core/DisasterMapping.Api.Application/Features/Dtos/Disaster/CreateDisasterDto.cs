using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Dtos.Disaster
{
    public class CreateDisasterDto
    {
        public DisasterType DisasterType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AddressId { get; set; }
        public AddressDto AddressDto { get; set; }
        public string Location { get; set; }
    }
}
