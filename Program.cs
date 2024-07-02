using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Truck_Loading_Application.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Truck_Loading_ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Truck_Loading_ApplicationContext") ?? throw new InvalidOperationException("Connection string 'Truck_Loading_ApplicationContext' not found.")));

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
