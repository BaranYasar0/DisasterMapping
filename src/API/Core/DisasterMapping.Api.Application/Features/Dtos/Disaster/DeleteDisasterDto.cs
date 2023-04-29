using DisasterMapping.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Dtos.Disaster
{
    public class DeleteDisasterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
