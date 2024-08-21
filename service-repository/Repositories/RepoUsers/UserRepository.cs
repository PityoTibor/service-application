using Microsoft.EntityFrameworkCore;
using service_repository.Exceptions;
using service_data.Models;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using service_data.Models.DTOs.RequestDto;

namespace service_repository.Repositories.RepoUsers
{
    public class UserRepository : IUserRepository
    {
        private readonly ServiceAppDbContext ctx;
        public UserRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> CreateAsync(CreateUserEntityDto user)
        {
            if (user != null)
            {
                if (IsValidUser(user))
                {
                    try
                    {
                        User newUser = new User()
                        {
                            User_id = Guid.NewGuid(),
                            Username = user.Username,
                            Email = user.Email,
                            Password = user.Password,
                            Role = user.Role,
                        };

                        await ctx.User.AddAsync(newUser);
                        ctx.SaveChanges();
                        return newUser;
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
                throw new UserUndefinedException() {ErrorMessage = "szar"};
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
            var res = await ctx.User.FindAsync(Id);
            if (res == null)
            {
                throw new UserNotFoundException(message: $"User with ID {Id} not found");
            }
            return res;
        }

        public async Task<User> GetOneByEmailAsync(string email)
        {
            var res = ctx.User
                     .Where(e => e.Email.Contains(email))
                     .Select(e => e)
                     .ToList()
                     .FirstOrDefault();
            //var res = await ctx.User.FindAsync(x => x.);
            if (res == null)
            {
                throw new UserNotFoundException(message: $"User with ID { email } not found");
            }
            return res;
        }

        public async Task<User> UpdateAsync(Guid Id, CreateUserEntityDto user)
        {
            if (IsValidUser(user))
            {
                var existingUser = await ctx.User.FirstOrDefaultAsync(x => x.User_id == Id);

                if (existingUser == null)
                {
                    throw new UserNotFoundException("User not found");
                }

                existingUser.Username = user.Username != null ? user.Username : existingUser.Username;
                existingUser.Password = user.Password != null ? user.Password : existingUser.Password;
                existingUser.Email = user.Email != null ? user.Email : existingUser.Email;
                existingUser.Role = user.Role != existingUser.Role ? user.Role : existingUser.Role;

                try
                {
                    ctx.User.Update(existingUser);
                    await ctx.SaveChangesAsync();
                    return existingUser;
                }
                catch (DbUpdateException ex)
                {
                    throw new DatabaseOperationException("Error updating user", ex);
                }
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }

        private bool IsValidUser(Object user)
        {
            if (user is CreateUserEntityDto)
            {
                return (user as CreateUserEntityDto).Username != null && (user as CreateUserEntityDto).Username.GetType() == typeof(string) &&
                (user as CreateUserEntityDto).Password != null && (user as CreateUserEntityDto).Password.GetType() == typeof(string) &&
                (user as CreateUserEntityDto).Email != null && (user as CreateUserEntityDto).Email.GetType() == typeof(string) &&
                (user as CreateUserEntityDto).Role != null && (user as CreateUserEntityDto).Role.GetType() == typeof(RoleEnum);
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
