using Attendance.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Domain.Interface
{
    public interface IUserRepo
    {
        Task<List<User>> Getall();
        Task<User> Post(User data);
        Task<User> Update(User data);
        Task<User> Delete(int id);
        Task<User> GetbyId(int id);


    }
}
