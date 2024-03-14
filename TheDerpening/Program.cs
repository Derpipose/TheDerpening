using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using TheDerpening.Data;
using TheDerpening.Services;

var builder = WebApplication.CreateBuilder(args);
string uri = "http://thederpeningapiimage:8080";
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ApiService>(provider =>
        {
            HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
            return new ApiService(httpclient);
        });



builder.Services.AddServerSideBlazor();
/*builder.Services.AddDbContextFactory<ListDbContext>((serviceProvider, options) => {
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration["DefaultConnection"];
    options.UseNpgsql(connectionString);
});*/

// builder.Services.

var app = builder.Build();
blue

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
