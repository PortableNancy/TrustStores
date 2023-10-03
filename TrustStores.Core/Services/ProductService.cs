using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.DTOs;
using TrustStores.Core.Interface;
using TrustStores.Core.Model;

namespace TrustStores.Core.Services
{
    public class ProductService: IProductService
    {

        public IUnitofWork _unitOfWork;
        private readonly ProductDto _productDto;

        public ProductService(IUnitofWork unitOfWork, ProductDto dto)
        {
            _unitOfWork = unitOfWork;
            _productDto = dto;

        }

        public async Task<ResponseDto<bool>> CreateProduct(ProductDto product)
        {
            var response = new ResponseDto<bool>();
            try
            {
                if (product != null)
                {
                    var newItem = new Product()
                    {

                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Category,


                    };
                    await _unitOfWork.Products.Add(newItem);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                    {
                        response.StatusCode = (int) HttpStatusCode.Created;
                        response.Message = "Successful";
                        response.Data = true;
                        return response;
                    
                    }
                    else
                    {
                        response.StatusCode = (int)HttpStatusCode.NotModified;
                        response.Message = "Failed";
                        response.Data = false;
                        return response;
                    }    
                      

                }
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Failed";
                response.Data = false;
                return response;
            
            }
            catch (Exception ex)
            {
                 response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                response.Data = false;
                return response;
            }
           
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId != null )
            {
                var product = await _unitOfWork.Products.GetById(productId);
                if (product != null)
                {
                    await _unitOfWork.Products.DeleteAsync(productId);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var Product = await _unitOfWork.Products.GetAll();
            return Product.ToList();
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var product = await _unitOfWork.Products.GetById(productId);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(int Id, ProductDto product)
        {
            if (product != null)
            {
                

                var newProduct = await _unitOfWork.Products.GetById(Id);
                if (newProduct != null)
                {
                    
                    newProduct.Name  = product.Name;
                    newProduct.Description = product.Description;
                    newProduct.Category = product.Category;

                    _unitOfWork.Products.Update(newProduct);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}

