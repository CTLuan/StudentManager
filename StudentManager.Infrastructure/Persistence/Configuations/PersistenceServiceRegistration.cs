using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManager.Infrastructure.Persistence.Context;

namespace StudentManager.Infrastructure.Persistence.Configuations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(); // 👈 Thêm dòng này
                }));

            return services;
        }
    }
}
