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
    public class UnitOfWork: IUnitofWork
    {
        private readonly TrustStoreDbContext _db;
        private IGenericRepository<Product> _productRepository; 

        public UnitOfWork(TrustStoreDbContext context)
        {
            _db = context;
                
        }
        public IGenericRepository<Product> ProductRepository => _productRepository ?? new GenericRepository<Product>(_db);
    }
}
