var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//builder.Services.AddIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
