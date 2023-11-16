using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddOcelot();



app.MapGet("/", () => "Welcome to the world");

app.Run();

await app.UseOcelot();
 