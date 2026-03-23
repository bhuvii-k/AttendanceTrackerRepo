using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Dto.Userdto
{
    public class Postdto
    {
        // 🔸 User fields
        public int Id { get; set; }          // required for update
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        // 🔸 Userdetails fields
        public string Fullname { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
    }
}
