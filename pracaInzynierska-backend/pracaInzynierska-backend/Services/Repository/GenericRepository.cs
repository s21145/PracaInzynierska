using Microsoft.EntityFrameworkCore;
using pracaInzynierska_backend.Models;
using System.Linq.Expressions;

namespace pracaInzynierska_backend.Services.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet =  context.Set<TEntity>();  
        }
        public  IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public  TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public  void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public  void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
    }
}
