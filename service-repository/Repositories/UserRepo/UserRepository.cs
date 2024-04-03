using Microsoft.EntityFrameworkCore;
using service_data.Exception;
using service_data.Exceptions;
using service_data.Models;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace service_repository.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly ServiceAppDbContext ctx;
        public UserRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user != null)
            {
                if (IsValidUser(user))
                {
                    try
                    {
                        ctx.User.Add(user);
                        await ctx.SaveChangesAsync();
                        return user;
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseOperationException(message: "Failed to save user", innerException: ex);
                    }
                }
                else
                {
                    throw new InvalidUserException(message: "Invalid user data");
                }
            }
            else
            {
                throw new UserUndefinedException(message: "User is null");
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var user = await GetOneAsync(Id); 

            if (user != null)
            {
                try
                {
                    ctx.User.Remove(user);
                    await ctx.SaveChangesAsync(); 
                    return true; 
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete user", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"User with ID {Id} not found");
            }
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            try
            {
                var query = ctx.User.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve users", innerException: ex);
            }
        }

        public async Task<User> GetOneAsync(Guid Id)
        {
            var user = ctx.User.FindAsync(Id);

            if (user.Result == null)
            {
                throw new UserNotFoundException(message: $"User with ID {Id} not found");
            }
            return user.Result;
        }

        public Task<User> UpdateAsync(Guid Id, User user)
        {
            throw new NotImplementedException();
        }


        private bool IsValidUser(User user)
        {
            return true;
        }
    }
}
