using CanteenCollegeAPI.Models;
using CanteenCollegeAPI.Models.Users;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetListUsers()
        {
            try
            {
                var result = await _usersServices.GetListUsers();
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
        public async Task<IActionResult> GetUsersById(int Id)
        {
            try
            {
                var result = await _usersServices.GetUsersById(Id);
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
        [HttpPost("login")]
        public async Task<IActionResult> GetUsersByLoginAndPass(Users user)
        {
            try
            {
                            var result = await _usersServices.GetByLoginAndPass(user);
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
        public async Task<IActionResult> InsertUsers(UsersInsert req)
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
                var result = await _usersServices.CreateUsers(req);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.InsertFail));
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
        public async Task<IActionResult> UpdateUsers(UsersUpdate req)
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
                var result = await _usersServices.UpdateUsers(req);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.UpdateFail));
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
        public async Task<IActionResult> DeleteUsers(int id)
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
                var result = await _usersServices.DeleteUsers(id);
                if (result == 0)
                {
                    return NotFound(new BaseResponse<object>(null, ErrorCode.Error, ErrorMessage.DeleteFail));
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
