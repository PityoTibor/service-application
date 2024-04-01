using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.EntityModels;

namespace service_repository.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<User> Create();
        Task<User> Update();
        Task<User> Delete();
        Task<User> DeleteAsync();
    }
}
