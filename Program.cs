using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Samit_For_Entertainment.Data;
using Samit_For_Entertainment.Data.Cart;
using Samit_For_Entertainment.Data.Services;
using Samit_For_Entertainment.Data.SERVICES;
using Samit_For_Entertainment.Models;
using Samit_For_EntertainmentE.Data.SERVICES;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dbcontext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IACTORSSERVICE, ACTORSSERVICE>();
builder.Services.AddScoped<ICINAMASSERVICE, CINAMASSERVICE>();
builder.Services.AddScoped<IMOVIESSERVICE, MOVIESSERVICE>();
builder.Services.AddScoped<IPRODUCERSSERVIC, PRODUCERSSERVIC>();
builder.Services.AddScoped<IOredersSERVICE, OrdersSERVICE>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GretSoppingCart(sc));
//Authentication and autherizations
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
//app authentication and autherizations
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//SEEDING DATABASE
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
app.Run();
