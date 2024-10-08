var builder = DistributedApplication.CreateBuilder(args);

var cryptoApi = builder.AddProject<Projects.Crypto_Api>("cryptoApi");
var apiAppService = builder.AddProject<Projects.Okala_Api_App>("apiAppservice");
builder.AddProject<Projects.Okala_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cryptoApi)
    .WithReference(apiAppService)
    ;

builder.Build().Run();
