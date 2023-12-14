using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Dishes;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class DishesServices : BaseDAL, IDishesServices
    {
        private readonly IFileService _fileService;

        public DishesServices(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<List<Dishes>> GetListDishes()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Dishes>(command);
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
        public async Task<List<Dishes>> GetListDishesInStock()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_ListInStock";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Dishes>(command);
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
        public async Task<Dishes> GetDishesById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Dishes>(command, parameters);
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
        public async Task<int> CreateDishes(DishesInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_Create @Name, @Image, @Price, @CategoryID, @Description, @Status, @StaffId";

                string imageUrl = _fileService.SaveFile(req.coverImage);

                var parameters = new DynamicParameters();
                parameters.Add("@Name", req.Name);
                parameters.Add("@Image", imageUrl);
                parameters.Add("@Price", req.Price);
                parameters.Add("@CategoryID", req.CategoryID);
                parameters.Add("@Description", req.Description);
                parameters.Add("@Status", req.Status);
                parameters.Add("@StaffId", req.StaffId);
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
        public async Task<int> UpdateDishes(DishesUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_Update @Id, @Name, @Image, @Price, @CategoryID, @Description, @Status, @StaffId";
                var currentDish = GetDishesById(req.ID).GetAwaiter().GetResult();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.ID);
                parameters.Add("@Name", req.Name);
                parameters.Add("@Price", req.Price);
                parameters.Add("@CategoryID", req.CategoryID);
                parameters.Add("@Description", req.Description);
                parameters.Add("@Status", req.Status);
                parameters.Add("@StaffId", req.StaffId);

                if (req.coverImage == null)
                {
                    parameters.Add("@Image", currentDish.Image);

                }
                else
                {
                    _fileService.Delete(currentDish.Image);
                    string imageUrl = _fileService.SaveFile(req.coverImage);
                    parameters.Add("@Image", imageUrl);
                }

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
        public async Task<int> DeleteDishes(int id)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Dishes_Delete @Id";
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
