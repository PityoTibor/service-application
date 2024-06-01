using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoCostumer
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly ServiceAppDbContext ctx;
        private readonly IUserRepository userRepository;
        public CostumerRepository(ServiceAppDbContext ctx, IUserRepository userRepository)
        {
            this.ctx = ctx;
            this.userRepository = userRepository;
        }
        public async Task<Costumer> CreateAsync(CreateCostumerEntityDto costumerUser)
        {
            User user = new User()
            {
                Email = costumerUser.Email,
                Password = costumerUser.Password,
                Role = costumerUser.Role,
                Username = costumerUser.Username,
                User_id = new Guid()
            };

            var createdUser = await userRepository.CreateAsync(user);

            if (costumerUser != null)
            {
                if (IsValidAdmin(costumerUser))
                {
                    try
                    {
                        Costumer costumer = new Costumer();
                        costumer.Costumer_id = Guid.NewGuid();
                        costumer.User = createdUser;

                        await ctx.Costumer.AddAsync(costumer);
                        ctx.SaveChanges();
                        //ez igy szar kell majd erre valami
                        return new Costumer();
                    }
                    catch (Exception ex)
                    {
                        throw new DatabaseOperationException(message: "Failed to save costumer", innerException: ex);
                    }
                }
                else
                {
                    throw new InvalidUserException(message: "Invalid user data") { message = "Invalid costumer data" };
                }
            }
            else
            {
                throw new UserUndefinedException() { ErrorMessage = "szar" };
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var costumerUser = await GetOneAsync(Id);
            if (costumerUser != null)
            {
                try
                {
                    ctx.Costumer.Remove(costumerUser);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete costumerUser", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"costumerUser with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Costumer>> GetAllAsync()
        {
            try
            {
                var query = ctx.Costumer.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve costumer", innerException: ex);
            }
        }

        public async Task<Costumer> GetOneAsync(Guid Id)
        {
            var res = await ctx.Costumer.FindAsync(Id);
            //var res3 = ctx.Handyman.Select(x => x);

            //foreach (var item in res3)
            //{
            //    await Console.Out.WriteLineAsync(item.Admin_id.ToString() + item.User_id.ToString());
            //}

            if (res == null)
            {
                throw new UserNotFoundException(message: $"costumerUser with ID {Id} not found");
            }
            return res;
        }

        public async Task<Costumer> UpdateAsync(Guid Id, CreateCostumerEntityDto costumerUser)
        {
            if (IsValidAdmin(costumerUser))
            {
                var existingCostumer = await ctx.Costumer.FirstOrDefaultAsync(x => x.Costumer_id == Id);

                if (existingCostumer == null)
                {
                    throw new UserNotFoundException("User not found");
                }
                //automapper
                var costumer = await GetOneAsync(Id);

                //itt ki kell szedni 
                User user = new User()
                {
                    Username = costumerUser.Username,
                    Email = costumerUser.Email,
                    Password = costumerUser.Password,
                    Role = costumerUser.Role
                };
                await userRepository.UpdateAsync(costumer.User_id, user);

                //existingUser.User_id.Username = adminUser.Username != null ? adminUser.Username : existingUser.User_id.Username;
                //existingUser.User_id.Password = adminUser.Password != null ? adminUser.Password : existingUser.User_id.Password;
                //existingUser.User_id.Email = adminUser.Email != null ? adminUser.Email : existingUser.User_id.Email;
                //existingUser.User_id.Role = adminUser.Role != existingUser.User_id.Role ? adminUser.Role : existingUser.User_id.Role;


                try
                {
                    ctx.Costumer.Update(existingCostumer);
                    await ctx.SaveChangesAsync();
                    return existingCostumer;
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

        private bool IsValidAdmin(Object costumer)
        {
            if (costumer is CreateCostumerEntityDto)
            {
                return (costumer as CreateCostumerEntityDto).Username != null && (costumer as CreateCostumerEntityDto).Username.GetType() == typeof(string) &&
                (costumer as CreateCostumerEntityDto).Password != null && (costumer as CreateCostumerEntityDto).Password.GetType() == typeof(string) &&
                (costumer as CreateCostumerEntityDto).Email != null && (costumer as CreateCostumerEntityDto).Email.GetType() == typeof(string) &&
                (costumer as CreateCostumerEntityDto).Role != null && (costumer as CreateCostumerEntityDto).Role.GetType() == typeof(RoleEnum);
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
