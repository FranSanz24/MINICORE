var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MINICORE_ApiService>("apiservice");

builder.AddProject<Projects.MINICORE_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
