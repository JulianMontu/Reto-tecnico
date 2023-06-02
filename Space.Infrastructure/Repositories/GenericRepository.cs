using Microsoft.EntityFrameworkCore;
using Space.Infrastructure.Persistence.Interfaces;
using Space.Infrastructure.Persistencia.Contexts;
using System.Linq.Expressions;

namespace Space.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitsOfWork _unitOfWork;
        private readonly SpaceContext _spaceContext;
        public GenericRepository(IUnitsOfWork unitOfWork, SpaceContext spaceContext)
        {
            _unitOfWork = unitOfWork;
            _spaceContext = spaceContext;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _spaceContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _spaceContext.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            try
            {
                var save = await _spaceContext.Set<T>().AddAsync(entity);

                if (save != null)
                    created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

    }
}
