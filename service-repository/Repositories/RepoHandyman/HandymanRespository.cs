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
        public async Task<HandymanResponseDto> CreateAsync(CreateHandymanEntityDto handymanUser)
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
                        return new HandymanResponseDto();
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

        public Task<Handyman> GetOneAsync(Guid Id)
        {
            //var res = await ctx.Admin.FindAsync(Id);
            //var res3 = ctx.Admin.Select(x => x);

            //foreach (var item in res3)
            //{
            //    await Console.Out.WriteLineAsync(item.Admin_id.ToString() + item.User_id.ToString());
            //}

            //if (res == null)
            //{
            //    throw new UserNotFoundException(message: $"adminUser with ID {Id} not found");
            //}
            //return res;
        }

        public Task<HandymanResponseDto> UpdateAsync(Guid Id, CreateHandymanEntityDto handyman)
        {
            throw new NotImplementedException();
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
