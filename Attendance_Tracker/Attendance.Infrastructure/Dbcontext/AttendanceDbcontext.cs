using Attendance.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Infrastructure.Dbcontext
{
  public class AttendanceDbcontext:DbContext
    {
        
        public AttendanceDbcontext(DbContextOptions<AttendanceDbcontext> options):base(options) { }

        public DbSet<User> user {  get; set; }
       
    }
}
