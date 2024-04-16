using service_data.Models;
using service_data.Models.DTOs;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoAdmin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ServiceAppDbContext ctx;
        public AdminRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Admin> CreateAsync(Admin admin)
        {
            admin = null;
            if (admin != null)
            {
                if (IsValidAdmin(admin))
                {
                    try
                    {
                        await ctx.Admin.AddAsync(admin);
                        return admin;
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseOperationException(message: "Failed to save user", innerException: ex);
                    }
                }
                else
                {
                    throw new InvalidUserException(message: "Invalid user data") { message = "Invalid user data" };
                }
            }
            else
            {
                throw new UserUndefinedException() { ErrorMessage = "szar" };
            }
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Admin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetOneAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> UpdateAsync(Guid Id, Admin user)
        {
            throw new NotImplementedException();
        }

        private bool IsValidAdmin(Object user)
        {
            if (user is User)
            {
                return (user as User).User_id != null && (user as User).User_id.GetType() == typeof(Guid) &&
                (user as User).Username != null && (user as User).Username.GetType() == typeof(string) &&
                (user as User).Password != null && (user as User).Password.GetType() == typeof(string) &&
                (user as User).Email != null && (user as User).Email.GetType() == typeof(string) &&
                (user as User).Role != null && (user as User).Role.GetType() == typeof(RoleEnum);
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
