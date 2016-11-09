using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;
using Jogging.DAL;
using System.Diagnostics;

namespace EntMob_Uni.Services
{
    public class UserService : IUserService
    {

        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return userRepository.PostUser(user);
        }

        public User CheckCredentials(User user)
        {
            try
            {
                User userByName = userRepository.GetUserByName(user.Name);
                if (BCrypt.Net.BCrypt.CheckPassword(user.Password, userByName.Password))
                {
                    return userByName;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine( "Test" + ex.Message);
            }

            return null;
        }
    }
}
