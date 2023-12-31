using EI_Task.Data;
using EI_Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            //Dependency Injection

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            //Run SeedDate

            using (var scope = ServiceProvider.CreateScope())
            {
                SeedData.Initialise(scope.ServiceProvider);
            }

            //Run the LoginForm

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());


        }

        public static IServiceProvider? ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EI_Task;Trusted_Connection=True;MultipleActiveResultSets=true";

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<LoginForm>();
                    services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);
                    services.AddScoped<ILibraryRepository<Book>, BooksRepository>();
                    services.AddScoped(typeof(ILibraryRepository<>), typeof(LibraryRepository<>));
                    services.AddScoped(typeof(ILibraryService<>), typeof(LibraryService<>));
                    services.AddScoped<IAccountService, AccountsService>();
                    services.AddScoped<IUserManagerService, UserManagerService>();
                    services.AddScoped<IBookManagerService, BookManagerService>();
                    services.AddScoped<IValidationService, ValidationService>();
                });
        }
    }
}