using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Order;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderService;
        public OrderController(IOrderServices orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetListOrders()
        {
            try
            {
                var result = await _orderService.GetListOrders();
                if (result == null)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpGet("get-grand-total-by-oder-id")]
        public async Task<IActionResult> GetGrandTotalByOrderId(int id)
        {
            try
            {
                var result = await _orderService.GetGrandTotalByOrderId(id);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpGet("get-list-by-status")]
        public async Task<IActionResult> GetListOrderByStatus(int Id)
        {
            try
            {
                var result = await _orderService.GetListOrderByStatus(Id);
                if (result == null)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpGet("get-list-by-user-id")]
        public async Task<IActionResult> GetListOrderByUserId(string Id)
        {
            try
            {
                var result = await _orderService.GetListOrderByUserId(Id);
                if (result == null)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
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
        public async Task<IActionResult> GetOrderById(int Id)
        {
            try
            {
                var result = await _orderService.GetOrderById(Id);
                if (result == null)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.DataNotFound, ErrorMessage.DataNotFound));
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
        public async Task<IActionResult> InsertOrder(OrderInsert req)
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
                var result = await _orderService.CreateOrder(req);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.InsertFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder(OrderUpdate req)
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
                var result = await _orderService.UpdateOrder(req);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.UpdateFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteOrder(int id)
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
                var result = await _orderService.DeleteOrder(id);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.DeleteFail));
                }
                return Ok(new BaseResponse<object>(result, ErrorCode.Success, ErrorMessage.Success));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ex.Message));
            }
        }
    }
}
