using DisasterMapping.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance
{
    public static class PersistanceRegistrationServices
    {
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DisasterConnectionString")));

            return services;
        }
    }
}
