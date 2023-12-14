using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Order;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class OrderServices : BaseDAL, IOrderServices
    {
        public async Task<List<Order>> GetListOrders()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Order>(command);
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
        public async Task<List<Order>> GetListOrderByUserId(string Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_List @UserId";
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", Id);
                var res = await conn.QueryAsync<Order>(command, parameters);
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
        public async Task<int> GetGrandTotalByOrderId(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_GrandTotalByOrderId @OrderId";
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", Id);
                var res = await conn.QueryAsync<int>(command, parameters);
                return res.FirstOrDefault();
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
        public async Task<List<Order>> GetListOrderByStatus(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_List null ,@Status";
                var parameters = new DynamicParameters();
                parameters.Add("@Status", Id);
                var res = await conn.QueryAsync<Order>(command, parameters);
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
        public async Task<Order> GetOrderById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Order>(command, parameters);
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
        public async Task<int> CreateOrder(OrderInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_Create @UserId";
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", req.UserId);
                var res = await conn.QueryFirstAsync<int>(command, parameters);
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
        public async Task<int> UpdateOrder(OrderUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_Update @Id, @Status";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.ID);
                parameters.Add("@Status", req.Status);
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
        public async Task<int> DeleteOrder(int id)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Order_Delete @Id";
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
