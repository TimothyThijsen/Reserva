using DataAccessLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReservaDesktopApp
{
    internal static class Program
    {
        internal static IServiceProvider ServiceProvider { get; }
            = CreateServiceProvider();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
        private static IServiceProvider CreateServiceProvider()
        {
            return new HostBuilder()
                .ConfigureServices(x =>
                {
                    string connectionString =
                        "Server=.;Database=WAD_20240422;User Id=sa;Password=SqlServer@2022!;" +
                        "Encrypt=True;TrustServerCertificate=True;";
                    x.AddSingleton<IHotelDAL, HotelDAL>();
                    x.AddSingleton<IRoomDAL, RoomDAL>();
                    x.AddSingleton<ICityDAL, CityDAL>();
                    x.AddSingleton<IActivityDAL, ActivityDAL>();
                    x.AddSingleton<CityManager>();
                    x.AddSingleton<RoomManager>();
                    x.AddSingleton<HotelManager>();
                    x.AddSingleton<ActivitiesManager>();
                    x.AddTransient<MemberDAL>();
                    x.AddSingleton<MemberManager>(provider =>
                    {
                        return new MemberManager(provider.GetRequiredService<MemberDAL>());
                    });
                    x.AddTransient<EmployeeDAL>();
                    x.AddSingleton<EmployeeManager>(provider =>
                    {
                        return new EmployeeManager(provider.GetRequiredService<EmployeeDAL>());
                    });
                })
                .Build()
                .Services;
        }
    }
}