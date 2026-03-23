using Attendance.Application.Dto.Attendancedto;
using Attendance.Application.Dto.Userdto;
using Attendance.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Mapper
{
    public class AttendanceProfile:Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Postdto, User>().ReverseMap();
            CreateMap<Attendencegetdto, AttendanceEntries>().ReverseMap();

        }
    }
}
