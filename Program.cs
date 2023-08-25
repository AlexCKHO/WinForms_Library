using EI_Task.Data;
using EI_Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Common;
using System.ComponentModel.Design;
using EI_Task.Data.Repositories;
using EI_Task.Services;

namespace EI_Task
{
    public static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<Form1>();
                    services.AddDbContext<LibraryDbContext>(
                        opt => opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EI_Task;Trusted_Connection=True;")
                        );
                    services.AddScoped<ILibraryRepository<Book>, BooksRepository>();
                    services.AddScoped(typeof(ILibraryRepository<>), typeof(LibraryRepository<>));
                    services.AddScoped(typeof(ILibraryService<>), typeof(LibraryService<>));
                    services.AddScoped<ILibraryService<Book>, BooksService>();

                });
        }
    }
}