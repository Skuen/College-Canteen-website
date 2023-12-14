using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Categories;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class CategoriesServices : BaseDAL, ICategoriesServices
    {
        public async Task<List<Categories>> GetListCategories()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Categories_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Categories>(command);
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
        public async Task<Categories> GetCategoriesById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Categories_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Categories>(command, parameters);
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
        public async Task<int> CreateCategories(CategoriesInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Categories_Create @Name, @Description";
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
        public async Task<int> UpdateCategories(CategoriesUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Categories_Update @Id, @Name, @Description";
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
        public async Task<int> DeleteCategories(int id)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Categories_Delete @Id";
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
    }
}
