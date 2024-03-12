using Microsoft.EntityFrameworkCore;
using TheDerpening.Data;
using TheDerpening.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

/*app.UseHttpsRedirection();
*/
app.UseAuthorization();

app.MapControllers();

app.Run();
