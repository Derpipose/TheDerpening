using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using TheDerpening.Data;
using TheDerpening.Services;

var builder = WebApplication.CreateBuilder(args);
// string uri = "http://thederpeningapiimage:8080";
string uri = Environment.GetEnvironmentVariable("apiaccess")?? throw new Exception("apiaccess Enviroment variable not set");
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ApiService>(provider =>
        {
            HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
            return new ApiService(httpclient);
        });



builder.Services.AddServerSideBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
