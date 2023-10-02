using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrustStores.Core.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(string id);
        void Update(T item);
        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
    }
}
