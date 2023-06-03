using System.Linq.Expressions;

namespace Space.Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<bool> CreateAsync(T entity);
    }
}
