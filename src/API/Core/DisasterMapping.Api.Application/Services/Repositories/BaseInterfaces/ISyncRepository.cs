using DisasterMapping.Api.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Services.Repositories.BaseInterfaces
{
    public interface ISyncRepository<T> where T : BaseEntity
    {
    }
}
