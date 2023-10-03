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
        Task Add(T entity);
        Task DeleteAsync(int Id);
        void Update(T item);
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetAll();
    }
}
