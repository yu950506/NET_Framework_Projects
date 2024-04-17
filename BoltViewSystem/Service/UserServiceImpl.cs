using BoltViewSystem.Dao;
using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public class UserServiceImpl : IUserService
    {
        private UserDao userDao = new UserDao();

        public List<Users> SelectUsers(Users user)
        {
          return userDao.SelectUsers(user);
        }
    }
}
