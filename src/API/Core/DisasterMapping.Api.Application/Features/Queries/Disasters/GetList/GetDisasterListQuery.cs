using AutoMapper;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Shared.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Queries.Disasters.GetList
{
    public class GetDisasterListQuery : IRequest<List<GetDisasterListDto>>
    {

        public class GetDisasterListQueryHandler : IRequestHandler<GetDisasterListQuery, List<GetDisasterListDto>>
        {
            private readonly IDisasterRepository _disasterRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<GetDisasterListQueryHandler> _logger;

            public GetDisasterListQueryHandler(IDisasterRepository disasterRepository, IMapper mapper, ILogger<GetDisasterListQueryHandler> logger)
            {
                _disasterRepository = disasterRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<List<GetDisasterListDto>> Handle(GetDisasterListQuery request, CancellationToken cancellationToken)
            {
                List<Disaster> disasters = await _disasterRepository.GetListAsync(include: x => x.Include(y => y.Address), orderBy: m=>m.OrderByDescending(o=>o.CreatedDate));
                List<GetDisasterListDto> mappedDisasters = _mapper.Map<List<GetDisasterListDto>>(disasters);
                _logger.LogInformation("Ürünler listelendi...");
                return mappedDisasters;
            }
        }
    }
}
