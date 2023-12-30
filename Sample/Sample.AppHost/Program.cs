var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.Sample_ApiService>("apiservice");

builder.AddProject<Projects.Sample_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();
