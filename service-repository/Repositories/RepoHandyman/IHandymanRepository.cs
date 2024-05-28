using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoHandyman
{
    public interface IHandymanRepository
    {
        Task<Handyman> CreateAsync(CreateHandymanEntityDto user);
        Task<Handyman> GetOneAsync(Guid Id);
        Task<IQueryable<Handyman>> GetAllAsync();
        Task<Handyman> UpdateAsync(Guid Id, CreateHandymanEntityDto handyman);
        Task<bool> DeleteAsync(Guid Id);
    }
}
