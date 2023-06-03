using DataBaseInMemory.DataContext.Data;
using Microsoft.EntityFrameworkCore;
using Space.Domain.Entities;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Infrastructure.Persistencia.Contexts
{
    public class SpaceContext : DbContext
    {
        
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public SpaceContext()
        {
        }

        public SpaceContext(DbContextOptions options) : base(options)
        {
           
        }


    }
}
