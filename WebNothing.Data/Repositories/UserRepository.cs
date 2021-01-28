using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Data.Context;
using WebNothing.Domain.Entities;
using WebNothing.Domain.Interfaces;

namespace WebNothing.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WebNothingContext context) : base(context)
        { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
