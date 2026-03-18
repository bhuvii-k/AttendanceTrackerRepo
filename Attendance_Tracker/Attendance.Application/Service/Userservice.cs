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

        public async Task<getdto> Delete(int id)
        {
            var result= await repo.Delete(id);
            var data = new getdto
            {
                Id=result.Id,


            };
        }

        public Task<List<getdto>> Getall()
        {
            throw new NotImplementedException();
        }

        public Task<getdto> Getuser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<getdto> Posttuser(Postdto data)
        {
            throw new NotImplementedException();
        }

        public Task<getdto> Update(Postdto data)
        {
            throw new NotImplementedException();
        }
    }
}


