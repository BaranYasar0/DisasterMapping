using DisasterMapping.Api.Application.Exceptions;
using DisasterMapping.Api.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Rules.Common
{
    public class BaseBusinessRules<T> where T:BaseEntity
    {
        public Task NullCheck(T model)
        {
            if (model == null)
                throw new BusinessException($"{model} is null!");
            return Task.CompletedTask;
        }
    }
}
