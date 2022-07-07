using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);
var ocelotConfig = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();
builder.Services
    .AddOcelot(ocelotConfig)
    .AddConsul();

var app = builder.Build();

app.UseRouting();
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
