using CategoryService.Models;
using CategoryService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(CategoryCreate category);
        Task<Category> GetCategoryById(int id);



    }
}
