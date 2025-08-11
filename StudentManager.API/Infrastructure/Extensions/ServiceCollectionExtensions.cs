using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentManager.API.GraphQL.Queries;
using StudentManager.API.GraphQL;
using StudentManager.API.Infrastructure.ExceptionMiddleware;
using StudentManager.Shared.Contants;
using System.Security.Claims;
using System.Text;

namespace StudentManager.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AddScoped, AddDbContext, AddAutoMapper, AddCors...
            //services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            // Cấu hình Authentication và Authorization
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        RoleClaimType = ClaimTypes.Role,
                        NameClaimType = ClaimTypes.Name,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                // Cấu hình Swagger để sử dụng JWT Bearer Token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });

            //services.AddAuthorization(option =>
            //{
            //    option.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            //});
              
            services.AddSignalR();


            //services.AddScoped<UserQuery>();
            //services.AddScoped<UserType>();
            //services.AddScoped<ISchema, AppSchema>();

            //services
            //    .AddGraphQL((options) =>
            //    {
            //        // Tuỳ chọn: Bật hoặc tắt cấu hình
            //        options.RequestServices = true; // Cho phép DI trong resolver
            //    })
            //    .AddSystemTextJson() // Dùng System.Text.Json thay vì Newtonsoft.Json
            //    .AddGraphTypes(typeof(AppSchema)); // Không cần chỉ định ServiceLifetime nếu mặc định là Scoped

            return services;
        }
    }
}
