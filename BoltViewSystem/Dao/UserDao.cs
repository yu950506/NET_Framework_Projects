using BoltViewSystem.Model;
using BoltViewSystem.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BoltViewSystem.Dao
{
    public class UserDao
    {
        public List<Users> SelectUsers(Users user)
        {
            List<Users> users;
            string sql = "select * from users where user = @user and password = @password";

            users = MySqlUtils.ExecuteQueryToList<Users>(sql, new MySqlParameter[]{
                new MySqlParameter("@user", user.User)
              , new MySqlParameter("@password", user.Password)
              });

            return users;
        }
    }
}