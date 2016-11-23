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
            throw new NotImplementedException();
        }

        public Task<User> CheckCredentials(User user)
        {
            throw new NotImplementedException();
        }
    }
}
