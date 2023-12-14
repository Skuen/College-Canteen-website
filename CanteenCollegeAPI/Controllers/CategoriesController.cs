using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Categories;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesService;

        public CategoriesController(ICategoriesServices categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetListCategories()
        {
            try
            {
                var result = await _categoriesService.GetListCategories();
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
        public async Task<IActionResult> GetCategoriesById(int Id)
        {
            try
            {
                var result = await _categoriesService.GetCategoriesById(Id);
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
        public async Task<IActionResult> InsertCategories(CategoriesInsert req)
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
                var result = await _categoriesService.CreateCategories(req);
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
        public async Task<IActionResult> UpdateCategories(CategoriesUpdate req)
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
                var result = await _categoriesService.UpdateCategories(req);
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
        public async Task<IActionResult> DeleteCategories(int id)
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
                var result = await _categoriesService.DeleteCategories(id);
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
