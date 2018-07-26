using System;
using Google.App.Core;
using Google.App.Core.Contracts;
using Google.App.Core.Controllers;
using Google.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Google.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();

            IEngine engine = new Engine(service);

            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<GoogleContext>(op => op.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
