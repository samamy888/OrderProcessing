using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

var builder = WebApplication.CreateBuilder(args);
var ocelotConfig = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();
builder.Services
    .AddOcelot(ocelotConfig)
    .AddConsul()
    .AddPolly()
    ;

var app = builder.Build();

app.UseRouting();
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
