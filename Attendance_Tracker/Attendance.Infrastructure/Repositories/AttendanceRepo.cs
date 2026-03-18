using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using Attendance.Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public async Task<string> Delete(int id)
        {
            var result = await context.Attendance.FindAsync(id);

            if (result == null)
            {
                return "Record not found";
            }

            context.Attendance.Remove(result);
            await context.SaveChangesAsync();

            return "Deleted successfully";
        }

        public async Task<AttendanceEntries> Get(int id)
        {
            var result = await context.Attendance.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<AttendanceEntries>> Getall()
        {
            var result=await context.Attendance.ToListAsync();
            return result;
           
        }

        public async Task<AttendanceEntries> Post(AttendanceEntries data)
        {
            try
            {
                
                    await context.Attendance.AddAsync(data);
                    await context.SaveChangesAsync();
                    
                
                return data;
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public async Task<AttendanceEntries> Update(AttendanceEntries data)
        {

            context.Attendance.Update(data);
            await context.SaveChangesAsync();
            return data;
        }
    }
}
