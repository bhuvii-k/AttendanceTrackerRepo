using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Dto.Attendancedto
{
    public class Attendencegetdto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RecordedBy { get; set; }

        public DateOnly Date { get; set; }
        public string status { get; set; }
        public string course { get; set; }

        public User User { get; set; }
        public User RecordedUser { get; set; }
    }
}
