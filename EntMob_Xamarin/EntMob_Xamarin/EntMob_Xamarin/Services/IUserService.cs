using EntMob.DAL;
using EntMob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin.Services
{
    public interface IUserService
    {

        User CheckCredentials(User user);
        User AddUser(User user);

    }
}
