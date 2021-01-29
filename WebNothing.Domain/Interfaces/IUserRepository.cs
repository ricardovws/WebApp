using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        IEnumerable<User> GetAll();

        //int GetNewId();
    }
}
