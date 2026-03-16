using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Dto.Userdto
{
   public class Postdto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

    }
}
