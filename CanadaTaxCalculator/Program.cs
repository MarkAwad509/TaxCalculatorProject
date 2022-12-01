using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models;
using TaxCalculator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TaxRateContext>(options => options.UseMySql(
     builder.Configuration.GetConnectionString("TaxRateDB"),
     ServerVersion.Parse("10.6.7-mariadb"))
 .UseLazyLoadingProxies());

builder.Services.AddScoped<TaxRateService>();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHealthChecks("/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
