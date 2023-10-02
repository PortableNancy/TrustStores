using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.Interface;
using TrustStores.Infrastructure.Datastore;

namespace TrustStores.Infrastructure.Repository
{
    public class GenericRepository<T> : GenericRepository<T> where T : class
    {
        private readonly TrustStoreDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TrustStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task InsertAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(string Id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(Id));
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            try
            {
                return await query.AsNoTracking().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();

        }
    }
