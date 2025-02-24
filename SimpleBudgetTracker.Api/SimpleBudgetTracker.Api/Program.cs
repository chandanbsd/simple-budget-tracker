using SimpleBudgetTracker.Api;
using SimpleBudgetTracker.Business.Services;
using SimpleBudgetTracker.Business.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(SimpleBudgetTracker.Business.MappingProfile));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
