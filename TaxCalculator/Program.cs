using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
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

builder.Services.AddHttpClient(name: "CanadaTaxCalculator", configureClient: options => {
    options.BaseAddress = new Uri("https://localhost:7253/");
    options.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json", 1.0)
    );
});

builder.Services.AddHttpClient(name: "QuebecTaxCalculator", configureClient: options => {
    options.BaseAddress = new Uri("https://localhost:7076/");
    options.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json", 1.0)
    );
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

