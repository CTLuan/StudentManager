using Serilog;
using StudentManager.API.GraphQL.Queries;
using StudentManager.API.GraphQL;
using StudentManager.API.Hubs;
using StudentManager.API.Infrastructure.ExceptionMiddleware;
using StudentManager.API.Infrastructure.Extensions;
using StudentManager.Application.DependencyInjection;
using StudentManager.Infrastructure.DependencyInjection;
using StudentManager.Infrastructure.Persistence.Configuations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddAPIServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(6000); // 👈 Listen trên port 5000
//});

// builder.WebHost.UseUrls("http://0.0.0.0:80");


builder.Services
    .AddGraphQLServer()
    .ModifyOptions(opt => opt.DefaultBindingBehavior = BindingBehavior.Implicit) // optional
    //.SetNamingConventions(NamingConventions.CamelCase) // 👈 Thêm dòng này
    .AddQueryType<Query>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (app.Environment.IsProduction())
//{
//    builder.WebHost.UseUrls("http://0.0.0.0:80");
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseGraphQL<ISchema>();
//app.UseGraphQLPlayground();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
//app.MapHub<ChatHub>("/chatHub");

app.MapGraphQL();

app.Run();

//public class Query
//{
//    public string Hello() => "world";
//}
