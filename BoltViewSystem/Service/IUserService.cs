using BoltViewSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Service
{
    public interface IUserService
    {

        List<Users> SelectUsers(Users user);
    }
}
