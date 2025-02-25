var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(name: "postgres-volume",isReadOnly: false)
    .WithPgWeb(pgWeb => pgWeb.WithHostPort(5050));

var postgresdb = postgres.AddDatabase("postgresdb");

builder.AddProject<Projects.SimpleBudgetTracker_Api>("simplebudgettracker-api")
    .WithReference(postgresdb);



builder.Build().Run();
