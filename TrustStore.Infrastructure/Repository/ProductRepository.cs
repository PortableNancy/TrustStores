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
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        public ProductRepository(TrustStoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
