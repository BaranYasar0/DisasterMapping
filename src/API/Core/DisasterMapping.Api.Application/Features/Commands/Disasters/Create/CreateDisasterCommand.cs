using AutoMapper;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Features.Rules.Disasters;
using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Commands.Disasters.Create
{
    public class CreateDisasterCommand : IRequest<CreateDisasterDto>
    {
        public DisasterType DisasterType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public int AddressId { get; set; }
        public AddressDto AddressDto { get; set; }
        public string Location { get; set; }

        public class CreateDisasterCommandHandler : IRequestHandler<CreateDisasterCommand, CreateDisasterDto>
        {
            private readonly IDisasterRepository _disasterRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<CreateDisasterCommandHandler> _logger;
            private readonly DisasterBusinessRules _disasterBusinessRules;

            public CreateDisasterCommandHandler(IDisasterRepository disasterRepository, IMapper mapper, DisasterBusinessRules disasterBusinessRules, ILogger<CreateDisasterCommandHandler> logger)
            {
                _disasterRepository = disasterRepository;
                _mapper = mapper;
                _disasterBusinessRules = disasterBusinessRules;
                _logger = logger;
            }

            public async Task<CreateDisasterDto> Handle(CreateDisasterCommand request, CancellationToken cancellationToken)
            {
                Disaster disaster = _mapper.Map<Disaster>(request);
                await _disasterBusinessRules.DisasterAddressExistsOrNot(disaster);
                
                Disaster addedDisaster = await _disasterRepository.AddAsync(disaster);
                CreateDisasterDto createdDisaster = _mapper.Map<CreateDisasterDto>(addedDisaster);
                _logger.LogInformation("Ürün Eklendi...");
                return createdDisaster;
            }
        }
    }
}
