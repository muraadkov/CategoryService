using CategoryService.Data;
using CategoryService.Models;
using CategoryService.Protos;
using CategoryService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(ProductCreate product)
        {
            await _context.Products.AddAsync(new Product() { Name = product.Name, CategoryId = product.CategoryId, Description = product.Description});
            await _context.SaveChangesAsync();
            return new Product() { Name = product.Name, CategoryId = product.CategoryId, Description = product.Description };
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
