using Attendance.Application.Dto.Userdto;
using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Interface
{
   public interface IuserService
    {
        Task<List<Postdto>> Getall(string role);
        Task<Postdto> Posttuser(Postdto data);
        Task<getdto> Getuser(int id);
        Task<Postdto> Update(Postdto  data);
        Task<getdto> Delete(int id);
        Task<claimdto> Login(Logindto data);
        Task<getdto> Postbyadmin(getdto dto);
        Task<Postdto> GetbyId(int id);
        Task<Userdetaildto> Postuserdetail(Userdetaildto data);
    } 
}
