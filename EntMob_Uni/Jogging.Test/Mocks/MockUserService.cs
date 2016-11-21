using EntMob_Uni.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;
using Jogging.DAL;

namespace Jogging.Test.Mocks
{
    class MockUserService : IUserService
    {

        private IUserRepository userRepository = new MockUserRepository();

        public Task<User> AddUser(User user)
        {
            return userRepository.PostUser(user);
        }

        public Task<User> CheckCredentials(User user)
        {
            return userRepository.GetUserByName(user.Name);
        }
    }
}
