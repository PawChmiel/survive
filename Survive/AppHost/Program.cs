var builder = DistributedApplication.CreateBuilder(args);

var surviveDbName = "survive";
/*var surviveDb = builder.AddPostgresContainer("postgres")
    // Set the name of the default database to auto-create on container startup.
    .WithEnvironment("POSTGRES_DB", surviveDbName)
    // Mount the SQL scripts directory into the container so that the init scripts run.
    .WithVolumeMount("../Survive.Api/data/postgres", "/docker-entrypoint-initdb.d", VolumeMountType.Bind)
    // Add the default database to the application model so that it can be referenced by other resources.
    .AddDatabase(surviveDbName);*/

var postgresdb2 = builder.AddPostgres(surviveDbName)
                        .AddDatabase("postgresdb");

builder.AddProject<Projects.Survive_Api>("survive.api")
    .WithReference(postgresdb2); ;

builder.Build().Run();
