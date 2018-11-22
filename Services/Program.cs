using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Unir.Repositories.Impl;
using Unir.Services;
using Unir.Services.Impl;
using Unir.Repositories.Impl.Context;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace z.test.unittest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();            
            serviceCollection.AddDbContext<PlanesDbContext>(o => o.UseSqlServer("Server=(localdb)\\v14.0;Database=PlanesDb;Trusted_Connection=True;ConnectRetryCount=0"));

            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)                
                .InNamespace("Unir.Services.Impl")
                .AsImplementedInterfaces()                
                .InstancePerDependency();
            containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .InNamespace("Unir.Repositories.Impl")
                .AsImplementedInterfaces()                
                .InstancePerDependency();

            containerBuilder.RegisterType<PlanesDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            // Ejemplo de uso de Servicio
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IPlanesService>();
                service.CrearPlan("Plan 1", 1, new[] { 1, 2, 3 });
            }

        }
    }
}
