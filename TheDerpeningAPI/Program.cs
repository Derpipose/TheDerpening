using Microsoft.EntityFrameworkCore;
using TheDerpening.Data;
using TheDerpening.Data.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var connectionstring = builder.Configuration.GetConnectionString("ListDb");
builder.Services.AddDbContext<ListDbContext>(options => options.UseNpgsql(connectionstring));

/*builder.Services.AddScoped<ListDbContext>();*/
builder.Services.AddScoped<ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment()) {*/
app.UseSwagger();
app.UseSwaggerUI();
/*}*/

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes= {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});
/*app.UseHttpsRedirection();
*/
app.UseAuthorization();

app.MapControllers();

app.Run();
