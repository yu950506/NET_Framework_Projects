using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltViewSystem.Model
{
    public class Users
    {
        public int id { get; set; } 
        public string User { get; set; }        
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now},Users ==>id =  {id},User = {User},Password = {Password}";
        }
    }
}
