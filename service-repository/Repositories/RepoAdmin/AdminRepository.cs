using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_data.Models.DTOs;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoAdmin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ServiceAppDbContext ctx;
        private readonly IUserRepository userRepository;
        public AdminRepository(ServiceAppDbContext ctx, IUserRepository userRepository)
        {
            this.ctx = ctx;
            this.userRepository = userRepository;
        }
        //kell majd dto, meg lehetséges, hogy uj migracio is kell
        public async Task<Admin> CreateAsync(CreateAdminEntityDto adminUser)
        {
            //kell majd egy mapper a userre, vagy egy factory
            User user = new User()
            {
                Email = adminUser.Email,
                Password = adminUser.Password,
                Role = adminUser.Role,
                Username = adminUser.Username,
                User_id = new Guid()
            };

            var createdUser = await userRepository.CreateAsync(user);

            if (adminUser != null)
            {
                if (IsValidAdmin(adminUser))
                {
                    try
                    {
                        Admin admin = new Admin();
                        admin.Admin_id = Guid.NewGuid();
                        admin.User = createdUser;

                        await ctx.Admin.AddAsync(admin);
                        ctx.SaveChanges();
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

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var adminUser = await GetOneAsync(Id);

            if (adminUser != null)
            {
                try
                {
                    ctx.Admin.Remove(adminUser);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete adminUser", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"adminUser with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Admin>> GetAllAsync()
        {
            try
            {
                var query = ctx.Admin.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve users", innerException: ex);
            }
        }  

        public async Task<Admin> GetOneAsync(Guid Id)
        {
            var res = await ctx.Admin.FindAsync(Id);
            var res3 = ctx.Admin.Select(x => x);

            //foreach (var item in res3)
            //{
            //    await Console.Out.WriteLineAsync(item.Admin_id.ToString() + item.User_id.ToString());
            //}

            if (res == null)
            {
                throw new UserNotFoundException(message: $"adminUser with ID {Id} not found");
            }
            return res;
        }

        public async Task<Admin> UpdateAsync(Guid Id, CreateAdminEntityDto adminUser)
        {
            if (IsValidAdmin(adminUser))
            {
                var existingAdminUser = await ctx.Admin.FirstOrDefaultAsync(x => x.Admin_id == Id);

                if (existingAdminUser == null)
                {
                    throw new UserNotFoundException("User not found");
                }
                //automapper
                var admin = await GetOneAsync(Id);

                //itt ki kell szedni 
                User user = new User()
                { 
                    Username = adminUser.Username,
                    Email = adminUser.Email,
                    Password = adminUser.Password,
                    Role = adminUser.Role
                };
                await userRepository.UpdateAsync(admin.User_id, user);

                //existingUser.User_id.Username = adminUser.Username != null ? adminUser.Username : existingUser.User_id.Username;
                //existingUser.User_id.Password = adminUser.Password != null ? adminUser.Password : existingUser.User_id.Password;
                //existingUser.User_id.Email = adminUser.Email != null ? adminUser.Email : existingUser.User_id.Email;
                //existingUser.User_id.Role = adminUser.Role != existingUser.User_id.Role ? adminUser.Role : existingUser.User_id.Role;


                try
                {
                    ctx.Admin.Update(existingAdminUser);
                    await ctx.SaveChangesAsync();
                    return existingAdminUser;
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

        private bool IsValidAdmin(Object admin)
        {
            if (admin is CreateAdminEntityDto)
            {
                return (admin as CreateAdminEntityDto).Username != null && (admin as CreateAdminEntityDto).Username.GetType() == typeof(string) &&
                (admin as CreateAdminEntityDto).Password != null && (admin as CreateAdminEntityDto).Password.GetType() == typeof(string) &&
                (admin as CreateAdminEntityDto).Email != null && (admin as CreateAdminEntityDto).Email.GetType() == typeof(string) &&
                (admin as CreateAdminEntityDto).Role != null && (admin as CreateAdminEntityDto).Role.GetType() == typeof(RoleEnum);
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
