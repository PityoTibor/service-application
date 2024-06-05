using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoHandyman
{
    public class HandymanRespository : IHandymanRepository
    {
        private readonly ServiceAppDbContext ctx;
        private readonly IUserRepository userRepository;
        public HandymanRespository(ServiceAppDbContext ctx, IUserRepository userRepository)
        {
            this.ctx = ctx;
            this.userRepository = userRepository;
        }
        public async Task<Handyman> CreateAsync(CreateHandymanEntityDto handymanUser)
        {
            User user = new User()
            {
                Email = handymanUser.Email,
                Password = handymanUser.Password,
                Role = handymanUser.Role,
                Username = handymanUser.Username,
                User_id = new Guid()
            };

            var createdUser = await userRepository.CreateAsync(user);

            if (handymanUser != null)
            {
                if (IsValidAdmin(handymanUser))
                {
                    try
                    {
                        Handyman handyman = new Handyman();
                        handyman.Handyman_id = Guid.NewGuid();
                        handyman.User = createdUser;

                        await ctx.Handyman.AddAsync(handyman);
                        ctx.SaveChanges();
                        //ez igy szar kell majd erre valami
                        return new Handyman();
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseOperationException(message: "Failed to save handyman", innerException: ex);
                    }
                }
                else
                {
                    throw new InvalidUserException(message: "Invalid user data") { message = "Invalid handyman data" };
                }
            }
            else
            {
                throw new UserUndefinedException() { ErrorMessage = "szar" };
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var handymanUser = await GetOneAsync(Id);
            if (handymanUser != null)
            {
                try
                {
                    ctx.Handyman.Remove(handymanUser);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete handymanUser", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"handymanUser with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Handyman>> GetAllAsync()
        {
            try
            {
                var query = ctx.Handyman.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve handyman", innerException: ex);
            }
        }

        public async Task<Handyman> GetOneAsync(Guid Id)
        {
            var res = await ctx.Handyman.FindAsync(Id);

            if (res == null)
            {
                throw new UserNotFoundException(message: $"adminUser with ID {Id} not found");
            }
            return res;
        }

        public async Task<Handyman> UpdateAsync(Guid Id, CreateHandymanEntityDto handymanUser)
        {
            if (IsValidAdmin(handymanUser))
            {
                var existingHandyman = await ctx.Handyman.FirstOrDefaultAsync(x => x.Handyman_id == Id);

                if (existingHandyman == null)
                {
                    throw new UserNotFoundException("User not found");
                }
                //automapper
                var handyman = await GetOneAsync(Id);

                //itt ki kell szedni 
                User user = new User()
                {
                    Username = handymanUser.Username,
                    Email = handymanUser.Email,
                    Password = handymanUser.Password,
                    Role = handymanUser.Role
                };
                await userRepository.UpdateAsync(handyman.User_id, user);

                //existingUser.User_id.Username = adminUser.Username != null ? adminUser.Username : existingUser.User_id.Username;
                //existingUser.User_id.Password = adminUser.Password != null ? adminUser.Password : existingUser.User_id.Password;
                //existingUser.User_id.Email = adminUser.Email != null ? adminUser.Email : existingUser.User_id.Email;
                //existingUser.User_id.Role = adminUser.Role != existingUser.User_id.Role ? adminUser.Role : existingUser.User_id.Role;


                try
                {
                    ctx.Handyman.Update(existingHandyman);
                    await ctx.SaveChangesAsync();
                    return existingHandyman;
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

        private bool IsValidAdmin(Object handyman)
        {
            if (handyman is CreateHandymanEntityDto)
            {
                return (handyman as CreateHandymanEntityDto).Username != null && (handyman as CreateHandymanEntityDto).Username.GetType() == typeof(string) &&
                (handyman as CreateHandymanEntityDto).Password != null && (handyman as CreateHandymanEntityDto).Password.GetType() == typeof(string) &&
                (handyman as CreateHandymanEntityDto).Email != null && (handyman as CreateHandymanEntityDto).Email.GetType() == typeof(string) &&
                (handyman as CreateHandymanEntityDto).Role != null && (handyman as CreateHandymanEntityDto).Role.GetType() == typeof(RoleEnum);
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
