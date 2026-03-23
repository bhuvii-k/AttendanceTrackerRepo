using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Dto.Userdto
{
   public class claimdto
    {
        public int Id {  get; set; }
        public string Username { get; set; }
        public string Role {  get; set; }
        public string Token { get; set; }
    }
}
