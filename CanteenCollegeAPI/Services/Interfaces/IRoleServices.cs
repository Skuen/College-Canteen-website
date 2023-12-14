using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IRoleServices
    {
        Task<List<Role>> GetListRoles();
        Task<Role> GetRoleById(int Id);
        Task<int> CreateRole(RoleInsert req);
        Task<int> UpdateRole(RoleUpdate req);
        Task<int> DeleteRole(DeleteRequest req);
    }
}
