using Attendance.Application.Dto.Userdto;
using Attendance.Application.Interface;
using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Application.Service
{
    public class Userservice : IuserService
    {
        private readonly IUserRepo repo;

        public Userservice(IUserRepo repo) 
        {
            this.repo = repo;
        }
        public async Task<List<getdto>> Getall()
        {
            var result = await repo.Getall();

            var data = result.Select(x => new getdto
            {
                Id = x.Id,
                Email = x.Email,
                Username = x.Username,
                RoleId = x.RoleId
            }).ToList();

            return data;
        }

        public Task<User> Posttuser(Postdto data)
        {
            throw new NotImplementedException();
        }


    }
}


