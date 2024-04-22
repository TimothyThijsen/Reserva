using DataAccessLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IHotelDAL, HotelDAL>();
builder.Services.AddSingleton<HotelManager>();
builder.Services.AddSingleton<ICityDAL, CityDAL>();
builder.Services.AddSingleton<CityManager>();
builder.Services.AddSingleton<IRoomDAL, RoomDAL>();
builder.Services.AddSingleton<RoomManager>();

builder.Services.AddRazorPages();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
});
builder.Services.AddSession(option =>
{
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
    option.IdleTimeout = TimeSpan.FromHours(2);
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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapRazorPages();

app.Run();
