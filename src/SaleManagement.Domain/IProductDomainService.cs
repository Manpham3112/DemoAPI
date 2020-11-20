using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public interface IProductDomainService : IDomainService
    {
        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        List<Product> SearchProduct(string searchString);
        Task UpdateProduct(Guid id, Product product);
        Task DeleteProduct(Guid id);
    }
}
