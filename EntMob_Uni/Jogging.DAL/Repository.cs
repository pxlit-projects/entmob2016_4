using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.DAL
{
    public abstract class Repository
    {

        public static User defaultUser = new User() { Name = "User", Password = "user" };

        protected const string BASE_URL = "http://192.168.1.40:8080";

    }
}
