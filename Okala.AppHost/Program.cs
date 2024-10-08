var builder = DistributedApplication.CreateBuilder(args);

var apiAppService = builder.AddProject<Projects.Okala_Api_App>("apiAppservice");
builder.AddProject<Projects.Crypto_Api>("cryptoApi")
    .WithExternalHttpEndpoints()
    .WithReference(apiAppService)
    ;

builder.Build().Run();
