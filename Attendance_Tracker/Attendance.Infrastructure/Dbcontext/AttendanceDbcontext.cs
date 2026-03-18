using Attendance.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Infrastructure.Dbcontext
{
    public class AttendanceDbcontext : DbContext
    {
        public AttendanceDbcontext(DbContextOptions<AttendanceDbcontext> options)
            : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<Userdetails> userdetails { get; set; }
        public DbSet<AttendanceEntries> Attendance { get; set; }
        public DbSet<Role> Roles {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship 1: Student
            modelBuilder.Entity<AttendanceEntries>()
                .HasOne(a => a.User)                         //Navigation Property present in the Attendence Entries  model class
                .WithMany(u => u.Attendances)                // Navigation property present in the User model class 
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship 2: Recorded By
            modelBuilder.Entity<AttendanceEntries>()            
                .HasOne(a => a.RecordedUser)                 //Navigation Property present in the Attendence Entries  model class
                .WithMany(u => u.RecordedAttendances)        // Navigation property present in the User model class 
                .HasForeignKey(a => a.RecordedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}