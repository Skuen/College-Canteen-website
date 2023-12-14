using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Role;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class RoleServices : BaseDAL, IRoleServices
    {
        public async Task<List<Role>> GetListRoles()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Role_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Role>(command);
                return res.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public async Task<Role> GetRoleById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Role_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Role>(command, parameters);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public async Task<int> CreateRole(RoleInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Role_Create @Name, @Description";
                var parameters = new DynamicParameters();
                parameters.Add("@Name", req.Name);
                parameters.Add("@Description", req.Description);
                var res = await conn.ExecuteAsync(command, parameters);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public async Task<int> UpdateRole(RoleUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Role_Update @Id, @Name, @Description";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.ID);
                parameters.Add("@Name", req.Name);
                parameters.Add("@Description", req.Description);
                var res = await conn.ExecuteAsync(command, parameters);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public async Task<int> DeleteRole(DeleteRequest req)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Role_Delete @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.Id);
                var res = await conn.ExecuteAsync(command, parameters);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
