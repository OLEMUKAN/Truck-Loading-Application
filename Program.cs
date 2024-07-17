using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Truck_Loading_Application;
using Truck_Loading_Application.Data;
using Truck_Loading_Application.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Truck_Loading_ApplicationContext")
    ?? throw new InvalidOperationException("Connection string 'Truck_Loading_ApplicationContext' not found.");

builder.Services.AddDbContext<Truck_Loading_ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Truck_Loading_ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.ConfigureApplicationCookie(options =>
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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();