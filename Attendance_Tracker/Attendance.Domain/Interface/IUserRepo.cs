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

    }
}
