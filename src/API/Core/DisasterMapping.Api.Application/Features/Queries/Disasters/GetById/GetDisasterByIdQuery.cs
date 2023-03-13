using AutoMapper;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Queries.Disasters.GetById
{
    public class GetDisasterByIdQuery:IRequest<GetDisasterByIdDto>
    {
        public int Id { get; set; }
        public class GetDisasterByIdQueryHandler : IRequestHandler<GetDisasterByIdQuery, GetDisasterByIdDto>
        {
            private readonly IDisasterRepository _disasterRepository;
            private readonly IMapper _mapper;

            public GetDisasterByIdQueryHandler(IDisasterRepository disasterRepository, IMapper mapper)
            {
                _disasterRepository = disasterRepository;
                _mapper = mapper;
            }

            public async Task<GetDisasterByIdDto> Handle(GetDisasterByIdQuery request, CancellationToken cancellationToken)
            {
                Disaster disaster = await _disasterRepository.GetAsync(predicate: x => x.Id == request.Id);
                GetDisasterByIdDto mappedDisaster = _mapper.Map<GetDisasterByIdDto>(disaster);
                return mappedDisaster;
            }
        }
    }
}
