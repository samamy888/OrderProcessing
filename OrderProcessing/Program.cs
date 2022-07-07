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
builder.Services.AddSwaggerGen(c =>

{

    c.SwaggerDoc("OrderProcess.Api", new OpenApiInfo { Title = "網關服務", Version = "v1" });

    c.DocInclusionPredicate((docName, description) => true);

    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

    var commentsFileName = "OrderProcess.Api.xml";

    var commentsFile = Path.Combine(baseDirectory, commentsFileName);

    c.IncludeXmlComments(commentsFile);

});
var app = builder.Build();

app.UseRouting();
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
