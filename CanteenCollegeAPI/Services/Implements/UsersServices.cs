using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Users;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class UsersServices : BaseDAL, IUsersServices
    {
        public async Task<List<Users>> GetListUsers()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Users>(command);
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
        public async Task<Users> GetUsersById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Users>(command, parameters);
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
        public async Task<int> CreateUsers(UsersInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_Create @Login, @Password, @Phone, @Email, @RoleId";
                var parameters = new DynamicParameters();
                parameters.Add("@Login", req.Login);
                parameters.Add("@Password", req.Password);
                parameters.Add("@Phone", req.Phone);
                parameters.Add("@Email", req.Email);
                parameters.Add("@RoleId", req.RoleId);
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
        public async Task<int> UpdateUsers(UsersUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_Update @Id, @Login, @Password, @Phone, @Email, @RoleId";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.ID);
                parameters.Add("@Login", req.Login);
                parameters.Add("@Password", req.Password);
                parameters.Add("@Phone", req.Phone);
                parameters.Add("@Email", req.Email);
                parameters.Add("@RoleId", req.RoleId);
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
        public async Task<int> DeleteUsers(int id)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_Delete @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
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
        public async Task<Users> GetByLoginAndPass(Users user)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Users_GetByLoginAndPass @Login, @Password";
                var parameters = new DynamicParameters();
                parameters.Add("@Login", user.Login);
                parameters.Add("@Password", user.Password);
                var res = await conn.QueryAsync<Users>(command, parameters);
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
    }
}
