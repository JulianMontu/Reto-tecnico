using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Space.Domain.Entities;
using Space.Infrastructure.Persistencia.Contexts;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;
using System;

namespace DataBaseInMemory.DataContext.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SpaceContext _context;

        public DbInitializer(SpaceContext context)
        {
            _context = context;
        }

        public void Initialize(SpaceContext context)
        {
            // Lógica de inicialización de la base de datos
            if (!_context.Vehiculos.Any())
            {
                _context.Vehiculos.AddRange(
                    new Vehiculo { Name = "Saturno V", Color = "Blanco", IsTripulate = 1, MaxSpeed = 100 },
                    new Vehiculo { Name = "Saturno V", Color = "Blanco", IsTripulate = 1, MaxSpeed = 100 },
                    new Vehiculo { Name = "Saturno V", Color = "Blanco", IsTripulate = 1, MaxSpeed = 100 }
                );

                _context.SaveChanges();
            }
        }
    }
}
