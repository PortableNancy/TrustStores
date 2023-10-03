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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TrustStoreDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TrustStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(Id));
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

    }

       
    }
