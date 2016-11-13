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

        public async Task<User> AddUser(User user)
        {
            return await userRepository.PostUser(user);
        }

        public async Task<User> CheckCredentials(User user)
        {
            try
            {
                User userByName = await userRepository.GetUserByName(user.Name);
                if (BCrypt.Net.BCrypt.CheckPassword(user.Password, userByName.Password))
                {
                    return userByName;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
