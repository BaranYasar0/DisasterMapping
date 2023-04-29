using AutoMapper;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Commands.Disasters.Delete
{
    public class DeleteDisasterCommand : IRequest<DeleteDisasterDto>
    {
        public int Id { get; set; }

        public class DeleteDisasterCommandHandler : IRequestHandler<DeleteDisasterCommand, DeleteDisasterDto>
        {
            private readonly IDisasterRepository _disasterRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<DeleteDisasterCommandHandler> _logger;

            public DeleteDisasterCommandHandler(IDisasterRepository disasterRepository, IMapper mapper, ILogger<DeleteDisasterCommandHandler> logger)
            {
                _disasterRepository = disasterRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<DeleteDisasterDto> Handle(DeleteDisasterCommand request, CancellationToken cancellationToken)
            {
                Disaster toBeDeletedDisaster = await _disasterRepository.GetAsync(x => x.Id == request.Id);
                Disaster deletedDisaster = await _disasterRepository.DeleteAsync(toBeDeletedDisaster);
                _logger.LogInformation("Disaster silme işlemi yapıldı!");
                DeleteDisasterDto mappedDisaster =_mapper.Map<DeleteDisasterDto>(deletedDisaster);
                return mappedDisaster;

            }
        }
    }
}
