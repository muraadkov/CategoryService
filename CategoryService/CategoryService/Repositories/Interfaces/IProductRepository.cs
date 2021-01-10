using CategoryService.Models;
using CategoryService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(ProductCreate category);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductsByCategoryId(int categoryId);
    }
}
