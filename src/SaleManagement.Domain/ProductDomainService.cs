using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public class ProductDomainService : DomainService, IProductDomainService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductDomainService(IRepository<Product> productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public string GetImagePath(string fileName)
        {
            return Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var existingProduct = _productRepository.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.PRODUCT_NAME_IS_TAKEN);
            }
            return await _productRepository.InsertAsync(product);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetListAsync();
        }

        public async Task UpdateProduct(Guid id, Product updatedProduct)
        {
            var product = _productRepository.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, SaleManagementDomainErrorCodes.PRODUCT_NOT_FOUND);
            }

            var sameNameProduct = _productRepository.FirstOrDefault(p => p.Name.ToLower() == updatedProduct.Name.ToLower());

            if (sameNameProduct != null && sameNameProduct.Id != id)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.PRODUCT_NAME_IS_TAKEN);
            }
            else
            {
                //var oldImagePath = GetImagePath(product.Image);
                //File.Delete(oldImagePath);

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Image = updatedProduct.Image;

                await _productRepository.UpdateAsync(product);
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetAsync(p => p.Id == id);
            if (product == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, SaleManagementDomainErrorCodes.PRODUCT_NOT_FOUND);
            }
            await _productRepository.DeleteAsync(p => p.Id == id);
            
            //var deleteImagePath = GetImagePath(product.Image);
            //File.Delete(deleteImagePath);
        }

        public List<Product> SearchProduct(string searchString)
        {
            return _productRepository
                .Where(p =>
                    p.Name.Contains(searchString)
                    ).ToList();
        }
    }
}
