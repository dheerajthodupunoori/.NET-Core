﻿using SwaggerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Interface
{
    public interface IUser
    {
        Task<User> Authenticate(string username, string password);
    }
}
