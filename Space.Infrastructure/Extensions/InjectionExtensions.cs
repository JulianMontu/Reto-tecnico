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
            services.AddDbContext<SpaceContext>(options =>
                options.UseInMemoryDatabase(databaseName: "InMemory_DB"));


            services.AddTransient<IDbInitializer, DbInitializer>();


            return services;
        }
    }

}
