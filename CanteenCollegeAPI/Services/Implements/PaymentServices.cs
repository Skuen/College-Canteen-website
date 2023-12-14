using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Payment;
using CanteenCollegeAPI.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class PaymentServices : BaseDAL, IPaymentServices
    {
        public async Task<List<Payment>> GetListPayment()
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Payment_List";
                //var parameters = new DynamicParameters();
                var res = await conn.QueryAsync<Payment>(command);
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
        public async Task<Payment> GetPaymentById(int Id)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Payment_GetById @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var res = await conn.QueryAsync<Payment>(command, parameters);
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
        public async Task<int> CreatePayment(PaymentInsert req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Payment_Create @StaffId, @OrderId";
                var parameters = new DynamicParameters();
                parameters.Add("@StaffId", req.StaffId);
                parameters.Add("@OrderId", req.OrderId);
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
        public async Task<int> UpdatePayment(PaymentUpdate req)
        {
            var conn = GetConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Payment_Update @Id, @StaffId, @OrderId";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", req.ID);
                parameters.Add("@StaffId", req.StaffId);
                parameters.Add("@OrderId", req.OrderId);
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
        public async Task<int> DeletePayment(int id)
        {
            var conn = GetConnection();
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string command = "exec Payment_Delete @Id";
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
