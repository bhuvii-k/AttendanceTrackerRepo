using Attendance.Application.Dto.Userdto;
using Attendance.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Attendance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService service;
        private readonly ILogger<UserController> _logger;

        public UserController(IuserService service, ILogger<UserController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                _logger.LogInformation("Fetching all users");

                var data = await service.Getall();

                _logger.LogInformation("Users fetched successfully");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching users");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostUsers(Postdto data)
        {
            try
            {
                _logger.LogInformation("Registering new user");

                var result = await service.Posttuser(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Logindto data)
        {
            try
            {
                _logger.LogInformation("User login attempt");

                var result = await service.Login(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Updateuser(Postdto data)
        {
            try
            {
                _logger.LogInformation("Updating user");

                var result = await service.Update(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating user");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Deleteuser(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting user with id: {id}");

                var result = await service.Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting user");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}