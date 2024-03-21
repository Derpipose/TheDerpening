using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using TheDerpening.Data;
using TheDerpening.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var connectionstring = builder.Configuration.GetConnectionString("ListDb");
builder.Services.AddDbContext<ListDbContext>(options => options.UseNpgsql(connectionstring));


builder.Services.AddScoped<ItemService>();

const string serviceName = "Derping";

builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddConsoleExporter()
        .AddOtlpExporter(o =>
            {
                o.Endpoint = new Uri("http://derp-otel-collector:4317");
            });
});



builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddConsoleExporter()
          .AddSource(DerpingMonitor.DerpString)
          .AddOtlpExporter(o =>
          {
              o.Endpoint = new Uri("http://derp-otel-collector:4317");
          }))
      .WithMetrics(metrics => metrics
          .AddAspNetCoreInstrumentation()
          .AddMeter("derpmetrics")
          .AddConsoleExporter()
          .AddOtlpExporter(o =>
          {
              o.Endpoint = new Uri("http://derp-otel-collector:4317");
          }));






var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment()) {*/
app.UseSwagger();
app.UseSwaggerUI();
/*}*/

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes = {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.MapGet("/api/makeBigger",  () =>
{
    DerpingMonitor.MyCountToTrack += 2;
});

/*app.UseHttpsRedirection();
*/
app.UseAuthorization();

app.MapControllers();

app.Run();
