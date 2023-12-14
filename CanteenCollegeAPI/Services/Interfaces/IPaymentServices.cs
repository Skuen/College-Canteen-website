using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IPaymentServices
    {
        Task<List<Payment>> GetListPayment();
        Task<Payment> GetPaymentById(int Id);
        Task<int> CreatePayment(PaymentInsert req);
        Task<int> UpdatePayment(PaymentUpdate req);
        Task<int> DeletePayment(int id);
    }
}
