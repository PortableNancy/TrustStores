using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.DTOs;
using TrustStores.Core.Model;

namespace TrustStores.Core.Interface
{
    public interface IProductService
    {

            Task<ResponseDto<bool>> CreateProduct( ProductDto product);
            Task<IEnumerable<Product>> GetAllProducts();

            Task<Product> GetProductById(int productId);

            Task<bool> UpdateProduct(int Id, ProductDto product);

            Task<bool> DeleteProduct(int productId);
        
    }
}
