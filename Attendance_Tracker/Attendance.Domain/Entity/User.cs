using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attendance.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId {  get; set; }
        public Role Role { get; set; }
        public ICollection<AttendanceEntries> Attendances { get; set; }
        public ICollection<AttendanceEntries> RecordedAttendances { get; set; }
    }
}
