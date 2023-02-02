﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructue.Abstracts
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}
