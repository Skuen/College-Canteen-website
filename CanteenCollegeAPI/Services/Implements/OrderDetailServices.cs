using CanteenCollegeAPI.Models.OrderDetail;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class OrderDetailServices : BaseDAL, IOrderDetailServices
    {
        public async Task<List<OrderDetailVM>> GetListOrderDetail()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec OrderDetail_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<OrderDetailVM>(command);
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
        public async Task<List<OrderDetailVM>> GetOrderDetailByOrderId(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec OrderDetail_GetByOrderId @OrderID";
                var parameters = new DynamicParameters();
                parameters.Add("@OrderID", Id);
                var res = await conn.QueryAsync<OrderDetailVM>(command, parameters);
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
        public async Task<int> CreateOrderDetail(OrderDetail req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec OrderDetail_Create @OrderId, @DishId, @Quantity";
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", req.OrderId);
                parameters.Add("@DishId", req.DishId);
                parameters.Add("@Quantity", req.Quantity);
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
