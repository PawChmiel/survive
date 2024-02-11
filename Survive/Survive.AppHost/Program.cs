var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Survive_Api>("survive.api");

builder.Build().Run();
