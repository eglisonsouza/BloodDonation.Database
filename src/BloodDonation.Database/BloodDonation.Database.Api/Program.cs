using BloodDonation.Database.Api.Filters;
using BloodDonation.Database.Application.Extensions;
using BloodDonation.Database.Core.Models.Config;
using BloodDonation.Database.Infrastructure.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection("Settings").Get<AppSettings>()!);

builder.Services.AddServiceCollection();
builder.Services.AddQueries();
builder.Services.AddControllers(
    options => options.Filters.Add(typeof(ExceptionDefaultFilter)
    
    )).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddContextSqlServer(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
