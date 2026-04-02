using Attendance.Application.Dto.Attendancedto;
using Attendance.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Attendance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceservice service;

        public AttendanceController(IAttendanceservice service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await service.Getall();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(attendancepostdto dto)
        {
            try
            {
                var data = await service.Post(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpGet("{id}/{fn}")]
        public async Task<IActionResult> Get(int id,string fn)
        {
            try
            {
                var data =await service.Getbyid(id,fn);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }

        }
        
        [HttpPut]
        public async Task<IActionResult> Put(attendancepostdto dto) 
        { 
            try
            {
               var data=await service.Put(dto);
               return Ok(data);
            }
            catch (Exception ex)
            {
               return StatusCode(500, new { error = ex.Message });
            }        
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data=await service.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
