using service_data.Models.EntityModels;
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
        public Task<User> CreateAsync(User user)
        {
            return userRepository.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            return userRepository.DeleteAsync(Id);
        }

        public Task<IQueryable<User>> GetAllAsync()
        {
            return userRepository.GetAllAsync();
        }

        public Task<User> GetOneAsync(Guid Id)
        {
            return userRepository.GetOneAsync(Id);
        }

        public Task<User> UpdateAsync(Guid Id, User user)
        {
            return userRepository.UpdateAsync(Id, user);
        }
    }
}
