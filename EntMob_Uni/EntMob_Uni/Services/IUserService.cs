﻿using Jogging.DAL;
using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Uni.Services
{
    public interface IUserService
    {

        Task<User> CheckCredentials(User user);
        Task<User> AddUser(User user);

    }
}
