using Microsoft.EntityFrameworkCore;
using project_asp_net.Models;
using Microsoft.AspNetCore.Identity;
using project_asp_net.Data;

var builder = WebApplication.CreateBuilder(args);

// Connexion à MySQL avec Pomelo
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<project_asp_netContext>();
builder.Services.AddDbContext<ClientContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));
builder.Services.AddDbContext<ReservationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));
builder.Services.AddDbContext<PromotionContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddDbContext<project_asp_netContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseAuthentication();

app.MapRazorPages();      // Important pour que Identity fonctionne


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservations}/{action=Index}/{id?}");

app.Run();
