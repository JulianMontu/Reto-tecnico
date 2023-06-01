using DataBaseInMemory.DataContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Space.Infrastructure.Persistencia.Contexts;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;

namespace POS.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var assembly = typeof(SpaceContext).Assembly.FullName;
            services.AddDbContext<SpaceContext>(options =>
                options.UseInMemoryDatabase(databaseName: "InMemory_DB"));

            // Configurar el DbInitializer para agregar datos predefinidos

            services.AddTransient<IDbInitializer, DbInitializer>();

            // Obtener el proveedor de servicios para obtener el contexto de la base de datos
            using (var serviceProvider = services.BuildServiceProvider())
            {
                // Obtener el contexto de la base de datos
                var context = serviceProvider.GetRequiredService<SpaceContext>();

                // Llamar al DbInitializer para agregar los datos predefinidos a la base de datos en memoria
                var dbInitializer = serviceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize(context);
            }

            return services;
        }

        //public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var assembly = typeof(SpaceContext).Assembly.FullName;
        //    services.AddDbContext<SpaceContext>(
        //        options => options.UseInMemoryDatabase("SpaceDB"), ServiceLifetime.Transient);

        //    return services;
        //}
    }
}
