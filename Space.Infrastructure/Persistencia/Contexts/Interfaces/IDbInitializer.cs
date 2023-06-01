using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Infrastructure.Persistencia.Contexts.Interfaces
{
    public interface IDbInitializer
    {
        public void Initialize(SpaceContext context);
    }
}
