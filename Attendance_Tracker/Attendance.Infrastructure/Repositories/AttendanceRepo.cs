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
    public class AttendanceRepo : IAttendance
    {
        private readonly AttendanceDbcontext context;

        public AttendanceRepo
            (AttendanceDbcontext context)
        {
            this.context = context;
        }
        public async Task<AttendanceEntries> Delete(int id)
        {
            try
            {
                var result = await context.Attendance.FindAsync(id);
                if (result == null) return null;

                context.Attendance.Remove(result);
                await context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"AttendanceRepo.Delete failed: {ex.Message}", ex);
            }
        }

        public async Task<AttendanceEntries> Get(int id)
        {
            try
            {
                var result = await context.Attendance.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"AttendanceRepo.Get failed: {ex.Message}", ex);
            }
        }

        public async Task<List<AttendanceEntries>> Getall()
        {
            try
            {
                var result=await context.Attendance.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"AttendanceRepo.Getall failed: {ex.Message}", ex);
            }
        }

        public async Task<AttendanceEntries> Post(AttendanceEntries data)
        {
            try
            {
                            await context.Attendance.AddAsync(data);
                    await context.SaveChangesAsync();
                    return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"AttendanceRepo.Post failed: {ex.Message}", ex);
            }
        }

        public async Task<AttendanceEntries> Update(AttendanceEntries data)
        {
            try
            {
                context.Attendance.Update(data);
                await context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"AttendanceRepo.Update failed: {ex.Message}", ex);
            }
        }
    }
}
