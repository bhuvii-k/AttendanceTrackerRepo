using Attendance.Application.Dto.Userdto;
using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using Attendance.Infrastructure.Dbcontext;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Infrastructure.Repositories
{
    public class UserRepo : IAttendence
    {
        private readonly AttendanceDbcontext context;

        public UserRepo
            (AttendanceDbcontext context) 
        {
            this.context = context;
        }

        public async Task<User> Delete(int id)
        {
           try
           {
               var result=await context.user.FirstOrDefaultAsync(x => x.Id == id);
               if (result == null) return null;
               context.Remove(result);
               await context.SaveChangesAsync();
               return result;
           }
           catch (Exception ex)
           {
               throw new Exception($"UserRepo.Delete failed: {ex.Message}", ex);
           }
        }

        public async Task<List<User>> Getall()
        {
            try
            {
                var result = await context.user
                    .Include(x => x.Userdetails)
                    .ToListAsync();   
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"UserRepo.Getall failed: {ex.Message}", ex);
            }
        }

        public async Task<User> GetbyId(int id)
        {
            try
            {
                var result = await context.user.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"UserRepo.GetbyId failed: {ex.Message}", ex);
            }
        }

        public async Task<User> Login(User data)
        {
            try
            {
                return await context.user
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.Username == data.Username &&
                    x.Password == data.Password);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserRepo.Login failed: {ex.Message}", ex);
            }
        }

        public async Task<User> Post(User data)
        {
            try
            {
                await context.user.AddAsync(data);
                await context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"UserRepo.Post failed: {ex.Message}", ex);
            }
        }

        public async Task<User> Update(User data)
        {
            try
            {
                var result= await context.user.FirstOrDefaultAsync(x=>x.Id==data.Id);
                if (result == null) return null;

                result.Username = data.Username;
                result.Password = data.Password;
                result.Email = data.Email;
                result.RoleId = data.RoleId;
                if (result.Userdetails !=null && data.Userdetails !=null)
                {
                    result.Userdetails.Fullname = data.Userdetails.Fullname;
                    result.Userdetails.DOB = data.Userdetails.DOB;
                    result.Userdetails.Gender = data.Userdetails.Gender;
                    result.Userdetails.DOB = data.Userdetails.DOB;
                    result.Userdetails.Phone = data.Userdetails.Phone;
                    result.Userdetails.Address = data.Userdetails.Address;
                    result.Userdetails.Department = data.Userdetails.Department;
                }
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"UserRepo.Update failed: {ex.Message}", ex);
            }
        }
    }
}
