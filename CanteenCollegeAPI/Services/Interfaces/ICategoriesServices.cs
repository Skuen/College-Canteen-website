using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface ICategoriesServices
    {
        Task<List<Categories>> GetListCategories();
        Task<Categories> GetCategoriesById(int Id);
        Task<int> CreateCategories(CategoriesInsert req);
        Task<int> UpdateCategories(CategoriesUpdate req);
        Task<int> DeleteCategories(int id);
    }
}
