using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using TruckDemo_v1.Application.Data;
using TruckDemo_v1.Domain.Entities.Identity;
using TruckDemo_v1.Infraestructure.Data;

namespace TruckDemo_v1.Infraestructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ITruckDemoContext, TruckDemoContext>
                (o => o.UseSqlServer(configuration["SqlServerConnectionString"]));

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<Role>()
           .AddEntityFrameworkStores<TruckDemoContext>().AddDefaultTokenProviders();

  
            return services;
        }
    }
}
