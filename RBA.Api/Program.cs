global using FluentValidation;

using Microsoft.AspNetCore.Authentication.Negotiate;

using FastEndpoints;
using Serilog;

using RBA.Repository;
using System.Text.Json;
using RBA.Api.EndPoints.AD;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting RBA.Api");
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

var connectionString = config.GetConnectionString("DefaultConnection");
Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
  IFreeSql fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.SqlServer, connectionString)
    .UseMonitorCommand(cmd => logger.Information($"Sql：{cmd.CommandText}"))
    .UseAutoSyncStructure(false)
    .Build();
  return fsql;
};
builder.Services.AddSingleton(fsqlFactory);

//Repositories
builder.Services.AddSingleton<IActionRepository, ActionRepository>();
builder.Services.AddSingleton<IApplicationRepository, ApplicationRepository>();
builder.Services.AddSingleton<IUserMesRepository, UserMesRepository>();
builder.Services.AddSingleton<IRoleActionRepository, RoleActionRepository>();
builder.Services.AddSingleton<IRolePlantRepository, RolePlantRepository>();
builder.Services.AddSingleton<IUserAllowedPlantRepository, UserAllowedPlantRepository>();
builder.Services.AddSingleton<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddSingleton<IVUserRolePlantRepository, VUserRolePlantRepository>();
builder.Services.AddSingleton<IVApplicationRoleActionRepository, VApplicationRoleActionRepository>();
builder.Services.AddSingleton<IOtherInfoRepository, OtherInfoRepository>();
builder.Services.AddSingleton<IAuditTrailRepository, AuditTrailRepository>();

builder.Services.AddFastEndpoints(o => o.IncludeAbstractValidators = true);
builder.Services.AddOpenApi();

var cors = config.GetSection("CorsOrigin:Allowed");
var allowedOrigins = cors.Get<string[]>();
if ((allowedOrigins == null) || (allowedOrigins.Length <= 0))
{
  allowedOrigins = [""];
}

builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", policy =>
  {
    policy.WithOrigins(allowedOrigins)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
  });
});

builder.Services.AddScoped<IADUserProvider, ADUserProvider>();

// Add Windows Authentication
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
  // By default, all incoming requests require authentication
  options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

app.UseFastEndpoints(c =>
{

  c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
  c.Serializer.RequestDeserializer = async (req, tDto, jCtx, ct) =>
  {
    using var reader = new StreamReader(req.Body);
    return Newtonsoft.Json.JsonConvert.DeserializeObject(await reader.ReadToEndAsync(ct), tDto);
  };

});

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<ADUserMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

public partial class Program { }
