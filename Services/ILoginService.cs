﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI_Task.Services
{
    public interface ILoginService
    {
        Task<int> LoginAsync(string email, string password);


    }
}
