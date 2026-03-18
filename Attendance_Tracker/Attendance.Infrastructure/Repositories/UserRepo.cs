using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using Attendance.Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AttendanceDbcontext context;

        public UserRepo
            (AttendanceDbcontext context) 
        {
            this.context = context;
        }

        public async Task<User> Delete(int id)
        {
           var result=await context.user.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(result);
            context.SaveChanges();
            return result;
        }

        public async Task<List<User>> Getall()

        {
            return await context.user.ToListAsync();
        }

        public async Task<User> GetbyId(int id)
        {
            var result = await context.user.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<User> Post(User data)
        {
            try
            {
                await context.user.AddAsync(data);
                await context.SaveChangesAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> Update(User data)
        {
            context.user.Update(data);
            context.SaveChangesAsync();
            return data;
        }
    }
}
