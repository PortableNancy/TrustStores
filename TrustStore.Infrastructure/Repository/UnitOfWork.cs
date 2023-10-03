using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.Interface;
using TrustStores.Core.Model;
using TrustStores.Infrastructure.Datastore;

namespace TrustStores.Infrastructure.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly TrustStoreDbContext _dbContext;
        public IProduct Products { get; }

        public UnitOfWork(TrustStoreDbContext dbContext,
                            IProduct productRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }

        }
    }
}
