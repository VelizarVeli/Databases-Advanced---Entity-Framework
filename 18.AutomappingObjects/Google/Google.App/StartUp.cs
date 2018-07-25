using System;
using Google.Data;
using Google.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Google.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<GoogleContext>(op => op.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
