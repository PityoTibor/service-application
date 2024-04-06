﻿using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_repository.Repositories.RepoUsers;

namespace service_logic.LogicUsers
{
    public class UserLogic : IUserLogic
    {
        public readonly IUserRepository userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> CreateAsync(User user)
        {
            try
            {
                return await userRepository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            return await userRepository.DeleteAsync(Id);
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> GetOneAsync(Guid Id)
        {
            return await userRepository.GetOneAsync(Id);
        }

        public async Task<User> UpdateAsync(Guid Id, User user)
        {
            return await userRepository.UpdateAsync(Id, user);
        }
    }
}
