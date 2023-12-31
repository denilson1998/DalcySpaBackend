﻿using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Persistence.Repositories
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User user);

        public Task<Client> GetClientAsync(int clientId);

        public Task<Beautician> GetBeauticianAsync(int beauticianId);
    }
}
