using AutoMapper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;

namespace service_application.AutomapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, CreateAdminEntityDto>();
        }
    }
}
