using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attendance.Application.Dto.Userdto
{
    public class Userdetaildto
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
    }
}
