using Attendance.Application.Dto.Userdto;
using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Interface
{
   public interface IuserService
    {
        Task<List<getdto>> Getall();
        Task<User> Posttuser(Postdto data);
    }
}
