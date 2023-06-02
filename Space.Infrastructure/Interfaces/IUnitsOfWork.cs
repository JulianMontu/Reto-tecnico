using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Infrastructure.Persistence.Interfaces
{
    public interface IUnitsOfWork : IDisposable
    {
        //Declaracion con matricula de nuestras interfaces a nivel de repositorio

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
