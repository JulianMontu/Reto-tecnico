using Space.Infrastructure.Persistence.Interfaces;
using Space.Infrastructure.Persistencia.Contexts;

namespace Space.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitsOfWork
    {
        private readonly SpaceContext _context;        
        public UnitOfWork(SpaceContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
