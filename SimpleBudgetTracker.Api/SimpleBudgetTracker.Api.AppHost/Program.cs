var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SimpleBudgetTracker_Api>("simplebudgettracker-api");

builder.Build().Run();
