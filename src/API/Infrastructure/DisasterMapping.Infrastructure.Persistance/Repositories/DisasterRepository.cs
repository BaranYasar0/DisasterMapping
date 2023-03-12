using DisasterMapping.Api.Application.Services.Repositories;
using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.Repositories
{
    public class DisasterRepository : BaseRepository<Disaster>, IDisasterRepository
    {
        public DisasterRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
