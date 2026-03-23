using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Domain.Interface
{
    public interface IAttendance
    {
        Task<List<AttendanceEntries>> Getall();
        Task<AttendanceEntries> Post(AttendanceEntries data);
        Task<AttendanceEntries> Update(AttendanceEntries data);
        Task<AttendanceEntries> Delete(int id);
        Task<AttendanceEntries> Get(int id);
    }
}
