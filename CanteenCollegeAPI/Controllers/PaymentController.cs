using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Payment;
using CanteenCollegeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetListPayment()
        {
            try
            {
                var result = await _paymentServices.GetListPayment();
                if (result == null)
                {
                    return Ok(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetPaymentById(int Id)
        {
            try
            {
                var result = await _paymentServices.GetPaymentById(Id);
                if (result == null)
                {
                    return Ok(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> InsertPayment(PaymentInsert req)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var error = ModelState.Where(e => e.Value.Errors.Count > 0)
                      .Select(e => e.Value.Errors.First().ErrorMessage)
                      .FirstOrDefault();
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, error));
                }
                var result = await _paymentServices.CreatePayment(req);
                if (result == 0)
                {
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.InsertFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePayment(PaymentUpdate req)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var error = ModelState.Where(e => e.Value.Errors.Count > 0)
                      .Select(e => e.Value.Errors.First().ErrorMessage)
                      .FirstOrDefault();
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, error));
                }
                var result = await _paymentServices.UpdatePayment(req);
                if (result == 0)
                {
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.UpdateFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var error = ModelState.Where(e => e.Value.Errors.Count > 0)
                      .Select(e => e.Value.Errors.First().ErrorMessage)
                      .FirstOrDefault();
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, error));
                }
                var result = await _paymentServices.DeletePayment(id);
                if (result == 0)
                {
                    return Ok(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.DeleteFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
    }
}
