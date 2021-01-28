using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
