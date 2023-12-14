using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IDishesServices
    {
        Task<List<Dishes>> GetListDishes();
        Task<List<Dishes>> GetListDishesInStock();
        Task<Dishes> GetDishesById(int Id);
        Task<int> CreateDishes(DishesInsert req);
        Task<int> UpdateDishes(DishesUpdate req);
        Task<int> DeleteDishes(int id);
    }
}
