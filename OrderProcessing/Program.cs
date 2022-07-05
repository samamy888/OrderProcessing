using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();

var app = builder.Build();

app.UseRouting();
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
