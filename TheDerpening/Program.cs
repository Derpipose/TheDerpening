using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheDerpening.Data;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
/*builder.Services.AddDbContextFactory<ListDbContext>((serviceProvider, options) => {
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration["DefaultConnection"];
    options.UseNpgsql(connectionString);
});*/
builder.Services.AddDbContextFactory<ListDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ListDb"))
    );

var app = builder.Build();

await Databasemigration(app.Services);

async Task Databasemigration(IServiceProvider services) {
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<DbContext>(); 
    if(ctx != null ) { 
        await ctx.Database.MigrateAsync();   
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
