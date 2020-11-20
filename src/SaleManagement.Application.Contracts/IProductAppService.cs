using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SaleManagement
{
    public interface IProductAppService: IApplicationService
    {
        Task CreateProduct(CreateUpdateProductDto input);

        Task<List<ProductDto>> GetProducts();

        List<ProductDto> SearchProduct(string searchString);

        Task UpdateProduct(Guid id, CreateUpdateProductDto input);

        Task DeleteProduct(Guid id);
    }
}
