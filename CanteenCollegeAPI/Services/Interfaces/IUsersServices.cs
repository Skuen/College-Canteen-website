using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IUsersServices
    {
        Task<List<Users>> GetListUsers();
        Task<Users> GetUsersById(int Id);
        Task<int> CreateUsers(UsersInsert req);
        Task<int> UpdateUsers(UsersUpdate req);
        Task<int> DeleteUsers(int id);
        Task<Users> GetByLoginAndPass(Users user);
    }
}
