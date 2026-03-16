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
        public async Task<List<User>> Getall()

        {
            return await context.user.ToListAsync();
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
    }
}
