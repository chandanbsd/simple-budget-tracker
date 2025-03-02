using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SimpleBudgetTracker.Data.Contexts;
using SimpleBudgetTracker.Data.Contexts.Interfaces;

namespace SimpleBudgetTracker.Api.Extensions;

public static class DatabaseExtension
{
    public static IHostApplicationBuilder AddDatabase(this IHostApplicationBuilder builder, string connectionString)
    {
        ////builder.AddNpgsqlDbContext<SimpleBudgetTrackerContext>(connectionName: "SimpleBudgetTrackerDB");

        builder.Services.AddDbContext<ISimpleBudgetTrackerContext, SimpleBudgetTrackerContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseLowerCaseNamingConvention();
            options.UseNpgsql(connectionString);
        });

        return builder;
    }
}
