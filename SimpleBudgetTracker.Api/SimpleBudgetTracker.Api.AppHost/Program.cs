
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(name: "SimpleBudgetTrackerVolumne", isReadOnly: false)
    .WithPgAdmin()
    .WithPgWeb(pgWeb => pgWeb.WithHostPort(5050));

var postgresdb = postgres.AddDatabase("SimpleBudgetTrackerDB");

builder.AddProject<Projects.SimpleBudgetTracker_Api>("simplebudgettracker-api")
    .WithReference(postgresdb);



builder.Build().Run();
