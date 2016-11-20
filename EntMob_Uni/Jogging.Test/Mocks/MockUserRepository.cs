using Jogging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;

namespace Jogging.Test.Mocks
{
    class MockUserRepository : IUserRepository
    {
        public Task<User> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> PostUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
