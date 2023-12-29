using BloodDonation.Database.Api.Filters;
using BloodDonation.Database.Application.Extensions;
using BloodDonation.Database.Core.Models.Config;
using BloodDonation.Database.Infrastructure.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection("Settings").Get<AppSettings>()!)
    .AddServiceCollection()
    .AddQueries()
    .AddCommands()
    .AddConsulConfiguration(builder.Configuration)
    .AddContextSqlServer(builder.Configuration)
    .AddRepositories()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers(
        options => options.Filters.Add(typeof(ExceptionDefaultFilter)
    )).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseConsul(builder.Configuration)
    .UseAuthorization();

app.MapControllers();

app.Run();
