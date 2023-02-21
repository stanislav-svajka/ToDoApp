using System.Text;

using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;


namespace ToDoAppBE.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            AddDatabase(services, configuration);
            AddServices(services);
            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            
        }

        #region Infrastructure
        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                //options.UseInMemoryDatabase("Visma.Bootcamp.eShop-db");
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    opts =>
                    {
                        opts.MigrationsAssembly("ToDoAppBe");
                    });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
        
        #endregion
    }
}
