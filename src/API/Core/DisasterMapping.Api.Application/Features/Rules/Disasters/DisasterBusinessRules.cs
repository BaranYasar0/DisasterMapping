using DisasterMapping.Api.Application.Exceptions;
using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Rules.Disasters
{
    public class DisasterBusinessRules
    {
        private readonly IDisasterRepository _disasterRepository;

        public DisasterBusinessRules(IDisasterRepository disasterRepository)
        {
            _disasterRepository = disasterRepository;
        }

        public async Task DisasterAddressExistsOrNot(Disaster disaster)
        {
          Disaster? gettedDisaster= await _disasterRepository?.GetAsync(predicate: x => x.Address.FullAddress ==disaster.Address.FullAddress, include: y => y.Include(z => z.Address));
            
            if (gettedDisaster!=null)
                throw new BusinessException($"Bu {gettedDisaster.Address.FullAddress} zaten kayıtlı");
        }
    }
}
