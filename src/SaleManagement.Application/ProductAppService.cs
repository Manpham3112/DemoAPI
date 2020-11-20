using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;

namespace SaleManagement
{
    public class ProductAppService :  ApplicationService, IProductAppService
    {
        private readonly IProductDomainService productDomainService;
        private readonly IGuidGenerator guidGenerator;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductAppService(IProductDomainService productDomainService, IGuidGenerator guidGenerator, IWebHostEnvironment webHostEnvironment)
        {
            this.productDomainService = productDomainService;
            this.guidGenerator = guidGenerator;
            this.webHostEnvironment = webHostEnvironment;
        }

        public string GetImageName(CreateUpdateProductDto input)
        {
            if (input.Image == null) return "";
            return GuidGenerator.Create().ToString() + Path.GetExtension(input.Image.FileName);
        }

        public string GetImagePath(string fileName)
        {
            return Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
        }

        public string GetImageURL(string fileName)
        {
            return Path.Combine("https://localhost:44393/images/", fileName);
        }

        public async Task StorageImageAsync(CreateUpdateProductDto input, string fileName)
        {
            var filePath = GetImagePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await input.Image.CopyToAsync(fileStream);
            }
        }

        public async Task CreateProduct(CreateUpdateProductDto input)
        {
            var fileName = GetImageName(input);
            //await StorageImageAsync(input, fileName);

            var product = new Product(guidGenerator.Create())
            {
                Name = input.Name,
                Price = input.Price,
                Amount = input.Amount,
                Image = fileName,
            };

            await productDomainService.CreateProduct(product);
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await productDomainService.GetProducts();
            var productDtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
            foreach (ProductDto productDto in productDtos)
            {
                productDto.Image = GetImageURL(productDto.Image);
            }
            return productDtos;
        }


        public async Task UpdateProduct(Guid id, CreateUpdateProductDto input)
        {
            var fileName = GetImageName(input);
            //await StorageImageAsync(input, fileName);

            var product = new Product(id)
            {
                Name = input.Name,
                Price = input.Price,
                Image = fileName
            };

            await productDomainService.UpdateProduct(id, product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await productDomainService.DeleteProduct(id);
        }

        public List<ProductDto> SearchProduct(string searchString)
        {
            var products = productDomainService.SearchProduct(searchString);
            var productDtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
            foreach (ProductDto productDto in productDtos)
            {
                productDto.Image = GetImageURL(productDto.Image);
            }
            return productDtos;
        }
    }
}
