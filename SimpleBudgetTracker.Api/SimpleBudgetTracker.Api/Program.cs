using Namotion.Reflection;
using Scalar.AspNetCore;
using SimpleBudgetTracker.Api;
using SimpleBudgetTracker.Api.Extensions;
using SimpleBudgetTracker.Business;
using SimpleBudgetTracker.Business.Services;
using SimpleBudgetTracker.Business.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(SimpleBudgetTracker.Business.SimpleBudgetTrackerProfile));

builder.Services.AddScoped<IUserService, UserService>();
string? databaseConnectionString = builder.Configuration.GetConnectionString("SimpleBudgetTrackerDB");

if(!string.IsNullOrWhiteSpace(databaseConnectionString))
{
    builder.AddDatabase(databaseConnectionString);
} else
{
    Console.WriteLine("\"Connection string 'postgresdb' not found\"");
    throw new Exception("Connection string 'postgresdb' not found");
}

builder.Services.AddOpenApiDocument();

builder.Services.AddAutoMapper(typeof(SimpleBudgetTrackerProfile));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
