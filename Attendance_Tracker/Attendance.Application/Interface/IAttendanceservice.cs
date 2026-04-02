using Attendance.Application.Dto.Attendancedto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Interface
{
    public interface IAttendanceservice
    {
        Task<List<Attendencegetdto>> Getall();
        Task<List<Attendencegetdto>> Getbyid(int id,string fn);
        Task<Attendencegetdto> Post(attendancepostdto dto);
        Task<Attendencegetdto> Put(attendancepostdto dto);
        Task<Attendencegetdto> Delete(int id);

    }
}
