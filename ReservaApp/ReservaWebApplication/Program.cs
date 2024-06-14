using DataAccessLayer;
using DomainLayer;
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
builder.Services.AddSingleton<IActivityDAL, ActivityDAL>();
builder.Services.AddSingleton<ActivitiesManager>();
builder.Services.AddSingleton(sp => TimeProvider.System);

builder.Services.AddTransient<RoomReservationDAL>();
builder.Services.AddTransient<ActivityReservationDAL>();
builder.Services.AddSingleton<GetReservationManager>(sp => reservationType =>
{
    switch (reservationType)
    {
        case ReservationType.RoomReservation:
            return new ReservationManager(sp.GetRequiredService<RoomReservationDAL>());
        default:
            return new ReservationManager(sp.GetRequiredService<ActivityReservationDAL>());
    }
});

builder.Services.AddTransient<MemberDAL>();
builder.Services.AddSingleton<MemberManager>(provider =>
{
    return new MemberManager(provider.GetRequiredService<MemberDAL>());
});
builder.Services.AddTransient<EmployeeDAL>();
builder.Services.AddSingleton<EmployeeManager>(provider =>
{
    return new EmployeeManager(provider.GetRequiredService<EmployeeDAL>());
});


builder.Services.AddRazorPages();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/AccountPages/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
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
