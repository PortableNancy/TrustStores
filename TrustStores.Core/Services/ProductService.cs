using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.DTOs;

namespace TrustStores.Core.Services
{
    public class ProductService
    {
        private readonly AddProductDto _product;
        public ProductService(AddProductDto dto)
        {
            _product = dto;
        }
        public void AddProduct(AddProductDto product)
        {

            var existingItem = product.Id 
        }
    }
}
