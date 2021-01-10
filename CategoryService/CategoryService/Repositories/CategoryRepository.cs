using CategoryService.Data;
using CategoryService.Models;
using CategoryService.Protos;
using CategoryService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context; 
        }
        public async Task<Category> AddCategory(CategoryCreate category)
        {
            await _context.Categories.AddAsync(new Category() { Name = category.Name, ParentCategoryId = category.ParentCategoryId });
            await _context.SaveChangesAsync();
            return new Category() { Name = category.Name, ParentCategoryId = category.ParentCategoryId };
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
