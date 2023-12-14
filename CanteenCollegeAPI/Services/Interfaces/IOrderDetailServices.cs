using CanteenCollegeAPI.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IOrderDetailServices
    {
        Task<List<OrderDetailVM>> GetListOrderDetail();
        Task<List<OrderDetailVM>> GetOrderDetailByOrderId(int Id);
        Task<int> CreateOrderDetail(OrderDetail req);
    }
}
