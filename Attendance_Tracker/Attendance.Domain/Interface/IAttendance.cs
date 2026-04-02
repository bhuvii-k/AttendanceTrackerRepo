using Attendance.Application.Dto.Attendancedto;
using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Domain.Interface
{
    public interface IAttendance
    {
        Task<List<customdto>> Getall();
        Task<AttendanceEntries> Post(AttendanceEntries data);
        Task<AttendanceEntries> Update(AttendanceEntries data);
        Task<AttendanceEntries> Delete(int id);
        Task<List<customdto>> Get(int id, string fn);
    }
}
