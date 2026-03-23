using Attendance.Application.Dto.Attendancedto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Interface
{
    public interface IAttendanceservice
    {
        Task<List<Attendencegetdto>> Getall();
        Task<Attendencegetdto> Getbyid(int id);
        Task<Attendencegetdto> Post(Attendencegetdto dto);
        Task<Attendencegetdto> Put(Attendencegetdto dto);
        Task<Attendencegetdto> Delete(int id);

    }
}
