using StudentManager.API.Infrastructure.ExceptionMiddleware;

namespace StudentManager.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AddScoped, AddDbContext, AddAutoMapper, AddCors...
            return services;
        }
    }
}
