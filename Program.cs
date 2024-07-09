using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Truck_Loading_Application;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;
var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddRazorPages();
    services.AddDbContext<Truck_Loading_ApplicationContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Truck_Loading_ApplicationContext")
            ?? throw new InvalidOperationException("Connection string 'Truck_Loading_ApplicationContext' not found.")));

    services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<Truck_Loading_ApplicationContext>()
        .AddDefaultTokenProviders();

    services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = Constants.AuthenticationPaths.Login;
        options.LogoutPath = Constants.AuthenticationPaths.Logout;
        options.AccessDeniedPath = Constants.AuthenticationPaths.AccessDenied;
    });
    var app = builder.Build();

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

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();
}