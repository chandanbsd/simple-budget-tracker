using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SimpleBudgetTracker.Api;
using SimpleBudgetTracker.Business.Services;
using SimpleBudgetTracker.Business.Services.Interfaces;
using SimpleBudgetTracker.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(SimpleBudgetTracker.Business.MappingProfile));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<SimpleBudgetTrackerContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("postgresdb")
    ?? throw new InvalidOperationException("Connection string 'postgresdb' not found")));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
