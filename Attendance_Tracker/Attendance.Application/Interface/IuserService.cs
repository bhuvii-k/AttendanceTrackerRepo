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
        Task<getdto> Posttuser(Postdto data);
        Task<getdto> Getuser(int id);
        Task<getdto> Update(Postdto  data);
        Task<getdto> Delete(int id);
    }
}
