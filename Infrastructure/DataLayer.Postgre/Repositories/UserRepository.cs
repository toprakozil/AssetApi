using DataLayer.Postgre.Common;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Postgre.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        ApplicationContext _dbContext;
        public UserRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }

        public User GetByUserName(string userName)
        {
            return _dbContext.Users.SingleOrDefault(c => c.UserName == userName);
        }

    }
}
