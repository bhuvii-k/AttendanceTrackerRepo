using Attendance.Application.Dto.Attendancedto;
using Attendance.Application.Dto.Userdto;
using Attendance.Application.Interface;
using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Application.Service
{
    public  class Attendanceservice:IAttendanceservice
    {
        private readonly IAttendance repo;
        private readonly IMapper mapper;

        public Attendanceservice(IAttendance repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<Attendencegetdto> Delete(int id)
        {
            try
            {
                var result = await repo.Delete(id);

                var returndata = new Attendencegetdto
                {
                    Id = result.Id,
                   
                };

                return returndata;
            }
            catch (Exception ex)
            {
                throw new Exception($"Attendanceservice.Delete failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Attendencegetdto>> Getall()
        {
            try
            {
                var result = await repo.Getall();

                var data = result.Select(x => new Attendencegetdto
                {
                    UserId = x.UserId,
                    RecordedBy = x.RecordedBy,
                    Id = x.Id,
                    username = x.UserName,
                    RecordedByName=x.RecordedByName,
                    status = x.status,
                    Date = x.Date,
                    course = x.course,
                }).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Attendanceservice.Getall failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Attendencegetdto>> Getbyid(int id, string fn)
        {
            try
            {
                var result=await repo.Get(id,fn);
                var data = result.Select(x => new Attendencegetdto
                {
                    UserId = x.UserId,
                    RecordedBy = x.RecordedBy,
                    Id = x.Id,
                    username = x.UserName,
                    RecordedByName = x.RecordedByName,
                    status = x.status,
                    Date = x.Date,
                    course = x.course,
                }).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Attendanceservice.Getbyid failed: {ex.Message}", ex);
            }
        }

        public async Task<Attendencegetdto> Post(attendancepostdto dto)
        {
            try
            {
                var result = new AttendanceEntries { 
                Id = dto.Id,
                UserId = dto.UserId,
                RecordedBy = dto.RecordedBy,
                Date = dto.Date,
                status=dto.status,
                course=dto.course,
                };

                var senddata=await repo.Post(result);
                var returndata = new Attendencegetdto {
                Id=senddata.Id,
                UserId=senddata.UserId,
                RecordedBy=senddata.RecordedBy,
                Date = senddata.Date,
                status=senddata.status,
                course=senddata.course,
                };

                return returndata;
            }
            catch (Exception ex)
            {
                throw new Exception($"Attendanceservice.Post failed: {ex.Message}", ex);
            }
        }

        public async Task<Attendencegetdto> Put(attendancepostdto dto)
        {
            try
            {
                var result = new AttendanceEntries {
                Id=dto.Id,
                UserId=dto.UserId,
                RecordedBy=dto.RecordedBy,
                Date = dto.Date,
                status=dto.status,
                course=dto.course,
                };

                var data= await repo.Update(result);
                var returndata = new Attendencegetdto {
                Id = data.Id,
                UserId=data.UserId,
                RecordedBy=data.RecordedBy,
                Date = data.Date,
                status=data.status,
                course=data.course,
                };
                return returndata;
            }
            catch (Exception ex)
            {
                throw new Exception($"Attendanceservice.Put failed: {ex.Message}", ex);
            }
        }
    }
}
