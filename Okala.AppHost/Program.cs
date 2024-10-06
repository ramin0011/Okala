var builder = DistributedApplication.CreateBuilder(args);

var crypto = builder.AddProject<Projects.Crypto_Api>("cryptoApi");
var apiAppService = builder.AddProject<Projects.Okala_Api_App>("apiAppservice");
builder.AddProject<Projects.Okala_Web>("webfrontend")
    .WithExternalHttpEndpoints()
   // .WithReference(apiService)
    .WithReference(apiAppService)
    ;

builder.Build().Run();
