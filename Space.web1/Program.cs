using POS.Infrastructure.Extensions;
using Space.Aplication.Interfaces;
using Space.Aplication.Services.Vehiculo;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;

namespace Space.web1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var Configuration = builder.Configuration;
            var services = builder.Services;

            services.AddAutoMapper(typeof(Program));
            services.AddInjectionInfraestructure(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IVehiculoServices, VehiculoServices>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var dbInitializer = serviceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }


            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var dbInitializer = services.GetRequiredService<IDbInitializer>();
            //    // Inicializar la base de datos
            //    dbInitializer.Initialize();
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}