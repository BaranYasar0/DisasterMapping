using DisasterMapping.Api.Application.Services.Repositories.BaseInterfaces;
using DisasterMapping.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Services.Repositories
{
    public interface IDisasterRepository:IRepository<Disaster>
    {
    }
}
