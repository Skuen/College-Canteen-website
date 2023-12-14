using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Dishes;
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
    public class DishesController : ControllerBase
    {
        private readonly IDishesServices _dishesServices;
        private readonly IFileService _fileService;

        public DishesController(IDishesServices dishesServices, IFileService fileService)
        {
            _dishesServices = dishesServices;
            _fileService = fileService;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetListDishes()
        {
            try
            {
                var result = await _dishesServices.GetListDishes();
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
        [HttpGet("get-list-in-stock")]
        public async Task<IActionResult> GetListDishesInStock()
        {
            try
            {
                var result = await _dishesServices.GetListDishesInStock();
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
        public async Task<IActionResult> GetDishesById(int Id)
        {
            try
            {
                var result = await _dishesServices.GetDishesById(Id);
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> InsertDishes([FromForm]DishesInsert req)
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
                var result = await _dishesServices.CreateDishes(req);
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateDishes([FromForm]DishesUpdate req)
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
                var result = await _dishesServices.UpdateDishes(req);
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
        public async Task<IActionResult> DeleteDishes(int id)
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
                var result = await _dishesServices.DeleteDishes(id);
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
