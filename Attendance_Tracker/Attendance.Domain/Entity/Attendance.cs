using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Domain.Entity
{
   public class Attendance
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public DateOnly Date {  get; set; }
        public string status {  get; set; }
        public string course {  get; set; }
        public int RecordedBy {  get; set; }

    }
}
