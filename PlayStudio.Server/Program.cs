using PlayStudio.Server.Extensions;

var builder = WebApplication.CreateBuilder(args).SetupBuilder();

var app = builder.Build().SetupApp();

app.Run();



