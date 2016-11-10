using EntMob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob.DAL
{
    public interface IUserRepository
    {

        User GetUserByName(string name);
        User PostUser(User user);

    }
}
