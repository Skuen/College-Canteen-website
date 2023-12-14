using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<List<Order>> GetListOrders();
        Task<List<Order>> GetListOrderByUserId(string Id);
        Task<List<Order>> GetListOrderByStatus(int Id);
        Task<Order> GetOrderById(int Id);
        Task<int> CreateOrder(OrderInsert req);
        Task<int> UpdateOrder(OrderUpdate req);
        Task<int> DeleteOrder(int id);
        Task<int> GetGrandTotalByOrderId(int Id);
    }
}
