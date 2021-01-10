using CategoryService.Protos;
using CategoryService.Repositories.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Services
{
    public class CategoryService : Shop.ShopBase
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ILogger<CategoryService> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public override async Task<CategoryInfo> AddCategory(CategoryCreate request, ServerCallContext context)
        {
            var res = await _categoryRepository.AddCategory(request);
            var categoryInfo = new CategoryInfo()
            {
                Id = res.Id,
                Name = res.Name,
                ParentCategoryId = res.ParentCategoryId
            };

            return await Task.FromResult(categoryInfo);
        }

        public override async Task<CategoryInfo> GetCategoryById(CategoryLookup request, ServerCallContext context)
        {
            var res = await _categoryRepository.GetCategoryById(request.Id);
            var categoryInfo = new CategoryInfo()
            {
                Id = res.Id,
                Name = res.Name,
                ParentCategoryId = res.ParentCategoryId
            };

            return await Task.FromResult(categoryInfo);
        }

        public override async Task<ProductInfo> AddProduct(ProductCreate request, ServerCallContext context)
        {
            var res = await _productRepository.AddProduct(request);
            var productInfo = new ProductInfo()
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description
            };

            return await Task.FromResult(productInfo);
        }

        public override async Task<ProductInfo> GetProductById(ProductLookup request, ServerCallContext context)
        {
            var res = await _productRepository.GetProductById(request.Id);
            var productInfo = new ProductInfo()
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description
            };

            return await Task.FromResult(productInfo);
        }

        public override async Task GetProductsByCategoryId(CategoryLookup request, IServerStreamWriter<ProductInfo> responseStream, ServerCallContext context)
        {
            var res = await _productRepository.GetProductById(request.Id);
            List<ProductInfo> list = null; 
            list.Add(new ProductInfo()
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description
            });

            await Task.FromResult(list);
        }
    }
}
