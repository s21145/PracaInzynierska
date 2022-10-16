using System.Linq.Expressions;

namespace pracaInzynierska_backend.Services.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAsync(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        public Task<TEntity> GetByIDAsync(object id);
        public Task InsertAsync(TEntity entity);
        public Task DeleteAsync(object id);
        public void Update(TEntity entityToUpdate);
    }
}
