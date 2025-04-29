using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.DAL.Interfaces;
using INFRASTRUCTURE.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace INFRASTRUCTURE.BLL
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
